using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ClassLibrary1
{
   [TestFixture]
   public class SomeTest
   {
      [Test]
      public static void TestCase1()
      {
         var postParameters = new Dictionary<string, string>
            {
               {"someNumber", "100"},
               {"someString", "Hello World"}
            };

         var resultWhenInConditional =
            (postParameters != null)
               ? postParameters
                    .Keys
                    .Zip(postParameters.Values,
                         (key, value) => string.Format("{0}={1}", key, value))
                    .Aggregate<string, string>(null,
                                               (prev, next) =>
                                               (prev != null)
                                                  ? string.Format("{0}&{1}", prev, next)
                                                  : next)
               : string.Empty;

         Assert.IsNotNull(resultWhenInConditional, "Result is NULL!");
      }

      [Test]
      public static void TestCase2()
      {
         Dictionary<string, string> postParameters = null;

         var resultWhenInConditional =
            (postParameters != null)
               ? postParameters
                    .Keys
                    .Zip(postParameters.Values,
                         (key, value) => string.Format("{0}={1}", key, value))
                    .Aggregate<string, string>(null,
                                               (prev, next) =>
                                               (prev != null)
                                                  ? string.Format("{0}&{1}", prev, next)
                                                  : next)
               : string.Empty;

         Assert.IsNotNull(resultWhenInConditional, "Result is NULL!");
      }

      [Test]
      public static void TestCase3()
      {
         Assert.IsNotNull(AsParam(null), "Result is NULL!");
      }

      [Test]
      public static void TestCase4()
      {
         var postParameters = new Dictionary<string, string>
            {
               {"someNumber", "100"},
               {"someString", "Hello World"}
            };
         var result = AsParam(postParameters);
         Assert.IsNotNull(result, "Result is NULL!");
      }

      public static string AsParam(IDictionary<string, string> postParameters)
      {
         var resultWhenInConditional =
            (postParameters != null)
               ? postParameters
                    .Keys
                    .Zip(postParameters.Values,
                         (key, value) => string.Format("{0}={1}", key, value))
                    .Aggregate<string, string>(null,
                                               (prev, next) =>
                                               (prev != null)
                                                  ? string.Format("{0}&{1}", prev, next)
                                                  : next)
               : string.Empty;

         // Place break point here
         return resultWhenInConditional;
      }
   }
}
