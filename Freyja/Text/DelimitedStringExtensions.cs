using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freyja.Text
{
    public static class DelimitedStringExtensions
    {
        const string CommaDelimiter = ",";

        /// <summary>
        /// Converts this string into an array.
        /// </summary>
        /// <typeparam name="T">The type of the array elements to convert to.</typeparam>
        /// <param name="input">The input string.</param>
        /// <param name="delimiter">The text the string is delimited by.</param>
        /// <param name="converter">The typeconverter used to convert elements to objects.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Thrown when input, delimiter or converter are null.</exception>
        public static T[] ParseArray<T>(this string input, string delimiter, TypeConverter converter)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (delimiter == null) throw new ArgumentNullException(nameof(delimiter));
            if (converter == null) throw new ArgumentNullException(nameof(converter));

            return input.Split(new[] { delimiter }, StringSplitOptions.None)
                .Select(s => (T)converter.ConvertFromString(s)).ToArray();
        }

        public static T[] ParseArray<T>(this string input, char delimiter, TypeConverter converter)
        {
            return ParseArray<T>(input, delimiter.ToString(), converter);
        }

        public static T[] ParseArray<T>(this string input, string delimiter)
        {
            return ParseArray<T>(input, delimiter, TypeDescriptor.GetConverter(typeof(T)));
        }

        public static T[] ParseArray<T>(this string input, char delimiter)
        {
            return ParseArray<T>(input, delimiter.ToString());
        }

        public static T[] ParseArray<T>(this string input, TypeConverter converter)
        {
            return ParseArray<T>(input, CommaDelimiter, converter);
        }

        public static T[] ParseArray<T>(this string input)
        {
            return ParseArray<T>(input, CommaDelimiter, TypeDescriptor.GetConverter(typeof(T)));
        }
    }
}
