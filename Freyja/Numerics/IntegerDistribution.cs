using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freyja.Numerics
{
    public class IntegerDistribution : IEnumerable<(long value, long count)>
    {
        readonly int threshold;
        long[] arrayDistribution;
        Dictionary<long, long> dictionaryDistribution;

        /// <summary>
        /// Initializes a new instance of the IntegerDistribution class with the given threshold.
        /// </summary>
        /// <param name="threshold">Values below threshold are logged faster at the expense of memory.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when threshold is negative.</exception>
        public IntegerDistribution(int threshold)
        {
            this.threshold = threshold >= 0 ? threshold : throw new ArgumentOutOfRangeException(nameof(threshold), threshold, "Cannot be negative");
            arrayDistribution = new long[threshold];
            dictionaryDistribution = new Dictionary<long, long>();
        }

        /// <summary>
        /// Increments the counter associated with the value in the distribution.
        /// </summary>
        /// <param name="value">The value whose counter will be incremented.</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when value is negative.</exception>
        public void Update(long value)
        {
            if (value < threshold)
            {
                arrayDistribution[value]++;
            }
            else
            {
                if (dictionaryDistribution.TryGetValue(value, out long count))
                {
                    dictionaryDistribution[value] = count + 1;
                }
                else
                {
                    dictionaryDistribution.Add(value, 1);
                }
            }
        }

        /// <summary>
        /// Removes all values and their counts from the distribution.
        /// </summary>
        public void Clear()
        {
            Array.Clear(arrayDistribution, 0, arrayDistribution.Length);
            dictionaryDistribution.Clear();
        }

        public IEnumerator<(long value, long count)> GetEnumerator()
        {
            for(int i = 0; i < arrayDistribution.Length; i++)
            {
                if (arrayDistribution[i] > 0)
                {
                    yield return (i, arrayDistribution[i]);
                }
            }

            foreach(var kvp in dictionaryDistribution)
            {
                yield return (kvp.Key, kvp.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
