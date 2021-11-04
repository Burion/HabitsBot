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
    }
}
