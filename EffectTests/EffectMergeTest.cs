using Microsoft.VisualStudio.TestTools.UnitTesting;
using EffectCore;
using System.Collections.Generic;

namespace EffectTests
{
    [TestClass]
    public class EffectMergeTest
    {
        [TestMethod]
        public void MergeSuccessTest()
        {
            Effect expected = Effect.Successful();

            IEnumerable<Effect> effects = new List<Effect>()
            {
                Effect.Successful(),
                Effect.Successful("OK"),                
                Effect.Successful("Done")
            };

            Effect actual = Effect.Merge(effects);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void MergeFailureTest()
        {
            Effect expected = Effect.Failure($"Error 1.{Effect._defaultMergeSeparator}Error 2.{Effect._defaultMergeSeparator}Error 3.");

            IEnumerable<Effect> effects = new List<Effect>()
            {
                Effect.Successful(),
                Effect.Successful("Test"),
                Effect.Failure("Error 1."),
                Effect.Successful(),
                Effect.Failure("Error 2."),
                Effect.Failure("Error 3.")
            };

            Effect actual = Effect.Merge(effects);
            Assert.AreEqual(expected,actual);
        }
    }
}
