using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HabitsBot.Tests.Helpers
{
    public class ExtensionTests
    {
        [Fact]
        public void ShieldTest()
        {
            var line = "Some text";

            var shielded = line.Shield("'");

            var shieldedCorrect = "'Some text'";

            Assert.Equal(shielded, shieldedCorrect);
        }

        [Fact]
        public void ShieldHTMLTest()
        {
            var line = "Some text";

            var shielded = line.ShieldHtmlTag("<b>");

            var shieldedCorrect = "<b>Some text</b>";

            Assert.Equal(shielded, shieldedCorrect);
        }

        [Fact]
        public void ShieldHTMLTestException()
        {
            var line = "Some text";

            Action shieldedAction = () => line.ShieldHtmlTag("<b");

            Assert.Throws<ArgumentException>(shieldedAction);
        }
    }
}
