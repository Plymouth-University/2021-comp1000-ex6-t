using System;
using System.Collections.Generic;
using Xunit;


namespace Exercise.Tests
{
   
    public class UnitTest1
    {
        private IGameReactor prog;
        public UnitTest1()
        {
            prog = (IGameReactor)new ProgramA();
        }

        [Fact]
        public void Test0()
        {
            
            Assert.True(typeof(IGameReactor).IsInstanceOfType(prog), $"All tests will only work once the interface is correctly used.");
        }


        [Theory]
        [InlineData("hello", "HELLO")]
        [InlineData("There was a long road, ahead of us.", "THERE WAS A LONG ROAD, AHEAD OF US.")]
        [InlineData("Christmas is upon us", "CHRISTMAS IS UPON US")]
        [InlineData("12345", "12345")]
        [InlineData("FINALLY WE ARE NEARLY DONE!", "FINALLY WE ARE NEARLY DONE!")]
        [InlineData("no rest for the ...", "NO REST FOR THE ...")]
        [InlineData("the end is nigh", "THE END IS NIGH")]
        public void Test1(string values, string result)
        {
            var outcome = prog.ConvertToUpperCase(values);
            Assert.True(outcome == result, $"For ConvertToUpperCase: You should have returned: <{result}> but did return <{outcome}>.");
        }

        [Theory]
        [InlineData('w', 1)]
        [InlineData('W', 1)]
        [InlineData('a', 2)]
        [InlineData('s', 3)]
        [InlineData('S', 3)]
        [InlineData(' ', 4)]
        [InlineData('A', 2)]
        [InlineData('L', 0)]
        [InlineData('i', 1)]
        [InlineData('d', 0)]
        [InlineData('k', 3)]
        [InlineData('J', 2)]
        public void Test2(char values, int result)
        {
            var outcome = prog.Move(values);
            Assert.True(outcome == result, $"For Move(char): You should have returned: <{result}> but did return <{outcome}>.");
        }

        [Theory]
        [InlineData(1, IGameReactor.PlayerDirection.North)]
        [InlineData(2, IGameReactor.PlayerDirection.West)]
        [InlineData(3, IGameReactor.PlayerDirection.South)]
        [InlineData(0, IGameReactor.PlayerDirection.East)]
        [InlineData(4, IGameReactor.PlayerDirection.Stay)]
        public void Test3(int values, IGameReactor.PlayerDirection result)
        {
            var outcome = prog.Move(values);
            Assert.True(outcome == result, $"For Move(int): You should have returned: <{result}> but did return <{outcome}>.");
        }


    }
}
