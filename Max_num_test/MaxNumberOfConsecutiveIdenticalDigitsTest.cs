using Max_num_unequal_consecutive_char;

namespace Max_num_test;

[TestClass]
public class MaxNumberOfConsecutiveIdenticalDigitsTest
{
    [TestMethod]
    public void NoRepeatingDigits_ReturnsError()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalDigits _instance = new MaxNumberOfConsecutiveIdenticalDigits();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalDigits("1234567890");
        bool result = _instance.listOfFinalStrings.Last().Length == 1;

        // Assert
        Assert.IsTrue(result, "The length of the final string should not be longer than 1!");
    }

    [TestMethod]
    public void ReturnsTwoStringsOfRepeatingDigits()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalDigits _instance = new MaxNumberOfConsecutiveIdenticalDigits();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalDigits("0011222333");
        string firstString = "222";
        string secondString = "333";
        bool result1 = _instance.listOfFinalStrings[0] == firstString;
        bool result2 = _instance.listOfFinalStrings[1] == secondString;

        // Assert
        Assert.IsTrue(result1, "First string should only be 222");
        Assert.IsTrue(result2, "Second string should only be 333");
    }

    [TestMethod]
    public void ReturnsOneStringOfRepeatingDigits()
    {
        // Arrange
        MaxNumberOfConsecutiveIdenticalDigits _instance = new MaxNumberOfConsecutiveIdenticalDigits();

        // Act
        _instance.GetMaxNumberOfConsecutiveIdenticalDigits("3216554");
        string finaltString = "55";
        bool result = _instance.listOfFinalStrings[0] == finaltString;

        // Assert
        Assert.IsTrue(result, "Final string should only be 55");
    }
}
