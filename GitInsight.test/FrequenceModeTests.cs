

using System.Collections.Generic;
using Moq;

namespace GitInsight.test;

public class FrequenceModeTests
{
    FrequenceMode _freq;
    public FrequenceModeTests()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        var target = @"/TestRepos/su19-grp7";
        FrequenceMode freq = new FrequenceMode();
        freq.Assemble(path + target);
        _freq = freq;
    }

    [Fact]
    public void TestFreqGetCorrectDate()
    {
        //arrange
        //Act
        var actual = _freq.NumberCommitsDaily.First().Item2;
        // Assert
        Assert.Equal("10-05-2019",actual);
    }
    // [Fact]
    // public void TestFreqGetCorrectAmountOfDifferentDates()
    // {
    //     // Given
    //     // When
    //     var actual = freqMode.NumberCommitsDaily.Count();
    //     // Then
    //     Assert.Equal(4,actual);
    // }
    // [Fact]
    // public void TestFreqDrawFunction()
    // {
    //     // Given
    //     using var writer = new StringWriter();
    //     Console.SetOut(writer);
    //     // When
    //     freqMode.Print();
    //     string output = writer.GetStringBuilder().ToString().TrimEnd();
    //     // Then
    //     Assert.Equal("",output);
    // }
}