using CraftsmanKata.GameOfLifeKata;
using NUnit.Framework;

namespace CraftsmanKata.UnitTests.GameOfLifeTests
{
    [TestFixture]
    public class GameOfLifeShould
    {
        public void CreateAGridOfSpecifiedSize()
        {
            var gameOfLife = new GameOfLife(3);
        }

    }
}
