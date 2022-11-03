

using System.Collections.Generic;

namespace GitInsight.test;

public class FrequenceModeTests
{
    // FrequenceMode freqMode;
    // public FrequenceModeTests()
    // {
    //     var repo = new Mock<IRepository>();
    //     Repository _repo = new Repository();
    //     FrequenceMode _freqMode = new FrequenceMode();
    //     var testmeme = new List<Signature>(){};
    //     var sig1 = new Signature("TestUser1","TestUser1",new System.DateTimeOffset(new System.DateTime(2000,10,10)));
    //     var sig2 = new Signature("TestUser2","TestUser1",new System.DateTimeOffset(new System.DateTime(2001,10,10)));
    //     var sig3 = new Signature("TestUser3","TestUser1",new System.DateTimeOffset(new System.DateTime(2002,10,10)));
    //     var sig4 = new Signature("TestUser4","TestUser1",new System.DateTimeOffset(new System.DateTime(2003,10,10)));
    //     testmeme.Add(sig1);
    //     testmeme.Add(sig2);
    //     testmeme.Add(sig3);
    //     testmeme.Add(sig4);
    //     _repo.Commit("",sig1,sig1,null); 
    //     _repo.Commit("",sig2,sig2,null); 
    //     _repo.Commit("",sig3,sig3,null); 
    //     _repo.Commit("",sig4,sig4,null); 
    //     _freqMode.Assemble(_repo);
    //     freqMode = _freqMode;
    // }

    // [Fact]
    // public void TestFreqGetCorrectDate()
    // {
    //     //arrange
    //     //Act
    //     var actual = freqMode.NumberCommitsDaily.First().Item2;
    //     // Assert
    //     Assert.Equal("",actual);
    // }
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