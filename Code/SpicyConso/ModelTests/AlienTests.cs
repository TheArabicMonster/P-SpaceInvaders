using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass()]
    public class AlienTests
    {
        [TestMethod()]
        public void AlienTest()
        {
            // Arrange
            int X = 10;
            int Y = 5;
            int HP = 20;

            // Act
            Alien alien = new(X, Y, HP);

            // Assert
            Assert.AreEqual(X, alien.AlienX);
            Assert.AreEqual(Y, alien.AlienY);
            Assert.AreEqual(HP, alien.AlienHP);
            Assert.IsFalse(alien.AlienEstMort);
        }

        [TestMethod()]
        public void DeplacementDroiteAlienTest()
        {
            // Arrange
            Alien alien = new(0, 0, 0);

            // Act
            alien.DeplacementDroiteAlien();

            // Assert
            Assert.AreEqual(2, alien.AlienX);
        }

        [TestMethod()]
        public void DeplacementDroiteAlienTestAlienChangeDirection()
        {
            // Arrange
            int largeurEcran = 150;
            int largeurAlien = 6;
            Alien alien = new(largeurEcran - largeurAlien - 2, 0, 0);

            // Act
            alien.DeplacementDroiteAlien();

            // Assert
            Assert.AreEqual(largeurEcran - largeurAlien, alien.AlienX);
            Assert.IsFalse(alien.AlienDirection);
        }
    }
}