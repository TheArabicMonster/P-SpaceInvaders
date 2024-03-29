﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass()]
    public class JoueurTests
    {
        [TestMethod()]
        public void JoueurTest()
        {
            // Arrange
            int X = 10;
            int Y = 5;

            // Act
            Joueur joueur = new(X, Y);

            // Assert
            Assert.AreEqual(X, joueur.JoueurX);
            Assert.AreEqual(Y, joueur.JoueurY);
            Assert.IsFalse(joueur.JoueurEstMort);
            Assert.AreEqual(20, joueur.JoueurHP);
        }

        [TestMethod()]
        public void DeplacementJoueurDroiteTest()
        {
            // Arrange
            Joueur joueur = new(0, 0);

            // Act
            joueur.DeplacementJoueurDroite();

            // Assert
            Assert.AreEqual(4, joueur.JoueurX);
        }

        [TestMethod()]
        public void DeplacementJoueurDroiteTestNeDépassePasLargeurEcran()
        {
            // Arrange
            int largeurEcran = 150;
            Joueur joueur = new(largeurEcran - 7, 0);

            // Act
            joueur.DeplacementJoueurDroite();

            // Assert
            Assert.AreEqual(largeurEcran - 7, joueur.JoueurX);
        }
    }
}