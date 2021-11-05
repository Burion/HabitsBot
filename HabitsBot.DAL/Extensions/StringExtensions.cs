using System;
using System.Collections.Generic;
using System.Text;

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

        public static string SingleQuotesShield(this string text) => text.Shield("'");
        public static string DoubleQuotesShield(this string text) => text.Shield("\"");
    }
}
