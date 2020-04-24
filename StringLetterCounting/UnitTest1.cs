using NUnit.Framework;
using System.Linq;

namespace StringLetterCounting
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GivenText_AndIsEmptyString_ShouldReturnEmptyString()
        {
            //Arrange
            string text = "";

            //Act
            string actual = StringLetterCount(text);
            string expected = "";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("The quick brown fox jumps over the lazy dog.", "1a1b1c1d3e1f1g2h1i1j1k1l1m1n4o1p1q2r1s2t2u1v1w1x1y1z")]
        [TestCase("The time you enjoy wasting is not wasted time.", "2a1d5e1g1h4i1j2m3n3o3s6t1u2w2y")]
        public void GivenText_AndTextHasCharacters_ShouldCalculateAmountOfOcurrenceForEachCharacter(string text, string expected)
        {
            //Arrange
            //string text = "The quick brown fox jumps over the lazy dog.";

            //Act
            string actual = StringLetterCount(text);
            //string expected = "1a1b1c1d3e1f1g2h1i1j1k1l1m1n4o1p1q2r1s2t2u1v1w1x1y1z";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void GivenText_AndTextHasCharacters2_ShouldCalculateAmountOfOcurrenceForEachCharacter()
        //{
        //    //Arrange
        //    string text = "The time you enjoy wasting is not wasted time.";

        //    //Act
        //    string actual = StringLetterCount(text);
        //    string expected = "2a1d5e1g1h4i1j2m3n3o3s6t1u2w2y";

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        [Test]
        public void GivenText_AndTextHasNoCharacters_ShouldReturnEmptyString()
        {
            //Arrange
            string text = "./4592#{}()";

            //Act
            string actual = StringLetterCount(text);
            string expected = "";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private string StringLetterCount(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            return string.Join("", text.Where(c => char.IsLetter(c) && !string.IsNullOrEmpty(c.ToString())).Select(c => c.ToString().ToLower()).OrderBy(c => c).GroupBy(c => c).Select(c => 
            {
                return $"{c.Count()}{c.Key}";
            }));

            //var result = string.Join("", myList);

            //var groupedText = text.OrderBy(c => c).GroupBy(c => c);

            //foreach (var groupItem in groupedText)
            //{
            //    //if (groupItem.Key != '.')
            //        result += $"{groupItem.Count()}{groupItem.Key}";
            //}

            //if (string.IsNullOrEmpty(text))
            //    return "";

            //if (text == "The quick brown fox jumps over the lazy dog.")
            //    return "1a1b1c1d3e1f1g2h1i1j1k1l1m1n4o1p1q2r1s2t2u1v1w1x1y1z";

            //if (text == "./4592#{}()")
            //    return "";

            //if (text == "The time you enjoy wasting is not wasted time.")
            //    return "2a1d5e1g1h4i1j2m3n3o3s6t1u2w2y";

            //throw new NotImplementedException();
        }
    }
}