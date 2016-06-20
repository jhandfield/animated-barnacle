using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROMSharp;

namespace UnitTests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod, TestCategory("Passwords")]
        public void Passwords_TooShort() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("asd"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_LowercaseOnly() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("asdfqwer"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_UppercaseOnly() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("QWERTYUIOP"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_SymbolsOnly() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("!@#$%^&*()"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_UpperLowerNoSymbol() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("asdfQWER"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_LowerSymbolNoUpper() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("asdf!@#$"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_UpperSymbolNoLower() {
            Assert.IsFalse(Password.MeetsComplexityRequirements("QWER!@#$"));
        }

        [TestMethod, TestCategory("Passwords")]
        public void Passwords_GoodPassword() {
            Assert.IsTrue(Password.MeetsComplexityRequirements("asdfQWER!@#"));
        }
    }
}
