using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HabitsBot.Tests.Helpers
{
    public static class StringExtensions
    {
        public static string Shield(this string text, string shield)
        {
            var sb = new StringBuilder(text);
            sb.Insert(0, shield);
            sb.Append(shield);

            return sb.ToString();
        }

        public static string ShieldHtmlTag(this string text, string shield)
        {
            var isTag = Regex.IsMatch(shield, "<[a-zA-Z]>");

            if (!isTag)
            {
                throw new ArgumentException("Given value is not HTML tag");
            }

            var open = shield;

            var openingSymbol = shield.Substring(0, 1);
            var close = new StringBuilder(openingSymbol);
            close.Append('/');
            close.Append(shield.Substring(1, shield.Length - 1));

            var sb = new StringBuilder(text);
            sb.Insert(0, open);
            sb.Append(close);

            return sb.ToString();
        }

        public static string SingleQuotesShield(this string text) => text.Shield("'");
        public static string DoubleQuotesShield(this string text) => text.Shield("\"");
    }
}
