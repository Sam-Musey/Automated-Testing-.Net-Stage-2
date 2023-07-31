using Max_num_unequal_consecutive_char;

namespace Max_num_test;

[TestClass]
public class MaxNumberOfConsecutiveIdenticalLatinLettersTest
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidInputString_ReturnsException()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalLatinLetters _instance = new MaxNumberOfConsecutiveIdenticalLatinLetters();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalLatinLetters("эррор");
    }

    [TestMethod]
    public void ReturnsTwoStringsOfConsecutiveIdenticalLatinLetters()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalLatinLetters _instance = new MaxNumberOfConsecutiveIdenticalLatinLetters();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalLatinLetters("xxyyyzzzxx");
        string firstString = "yyy";
        string secondString = "zzz";
        bool result1 = _instance.listOfFinalStrings[0] == firstString;
        bool result2 = _instance.listOfFinalStrings[1] == secondString;

        // Assert
        Assert.IsTrue(result1, "First string should only be 'yyy'");
        Assert.IsTrue(result2, "First string should only be 'zzz'");
    }

    [TestMethod]
    public void ReturnsLengthOfString5()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalLatinLetters _instance = new MaxNumberOfConsecutiveIdenticalLatinLetters();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalLatinLetters("stopdddddreaming");
        string finalString = "ddddd";
        bool result = _instance.count == finalString.Length;
            
        // Assert
        Assert.IsTrue(result, "Final string 'ddddd' should only be of size 5");
    }
}
