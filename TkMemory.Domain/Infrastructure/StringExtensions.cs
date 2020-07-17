using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TkMemory.Domain.Infrastructure
{
    internal static class StringExtensions
    {
        private static readonly Regex CamelCaseRegex = new Regex(@"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", RegexOptions.Compiled);

        internal static string CamelCaseToString(this string value)
        {
            return CamelCaseRegex.Replace(value, " $1");
        }

        internal static string RemoveApostrohes(this string value)
        {
            return value.Replace("'", string.Empty);
        }

        internal static string Sort(this string value)
        {
            var lines = new List<string>(value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            lines.Sort();
            return new StringBuilder(string.Join(Environment.NewLine, lines.ToArray())).ToString();
        }
    }
}
