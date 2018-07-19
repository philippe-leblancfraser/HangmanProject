using System;
using Xunit;
using GamingService;
using GamingService.DataType;

namespace GamingService.Test
{
    public class UnitTest1
    {
        private readonly GameService _gameService;

        public UnitTest1()
        {
            _gameService = new GameService();
        }

        [Fact]
        public void Test1()
        {
            Game randomGame =_gameService.GetRandomGame().GetAwaiter().GetResult();

            Console.WriteLine(randomGame.Name);

            Assert.True(true);
        }
    }
}
