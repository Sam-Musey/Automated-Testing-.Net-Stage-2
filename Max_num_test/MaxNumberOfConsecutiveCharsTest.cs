using Max_num_unequal_consecutive_char;

namespace Max_num_test;

[TestClass]
public class MaxNumberOfConsecutiveCharsTest
{
    [TestMethod]
    public void ReturnsOneStringOfRepeatingChars()
    {
        // Arrange
        MaxNumberOfConsecutiveChars _instance = new MaxNumberOfConsecutiveChars();
        
        // Act
        _instance.GetMaxNumberOfConsecutiveChars("iknowsomething");
        string finalString = "wsomething";
        bool result1 = _instance.listOfFinalStrings[0] == finalString;
        
        // Assert
        Assert.IsTrue(result1, "Final string should only be 'wsomething'");
    }
    
    [TestMethod]
    public void ReturnsTwoStringOfRepeatingChars()
    {
        // Arrange
        MaxNumberOfConsecutiveChars _instance = new MaxNumberOfConsecutiveChars();

        // Act
        _instance.GetMaxNumberOfConsecutiveChars("iknownothing");
        string firstString = "wnothi";
        string secondString = "othing";
        bool result1 = _instance.listOfFinalStrings[0] == firstString;
        bool result2 = _instance.listOfFinalStrings[1] == secondString;

        // Assert
        Assert.IsTrue(result1, "First string should only be 'wnothi'");
        Assert.IsTrue(result2, "First string should only be 'othing'");
    }

    [TestMethod]
    public void AllIdenticalCharsReturnsError()
    {
        // Arrange
        MaxNumberOfConsecutiveChars _instance = new MaxNumberOfConsecutiveChars();

        // Act
        _instance.GetMaxNumberOfConsecutiveChars("wwwww");
        string finalString = "w";
        bool result1 = _instance.listOfFinalStrings[0] == finalString;

        // Assert
        Assert.IsTrue(result1, "Final string should only contain a single character 'w'");
    }
}
