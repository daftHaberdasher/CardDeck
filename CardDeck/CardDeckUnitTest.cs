using NUnit.Framework;
using System;
namespace CardDeck
{
    [TestFixture()]
    public class CardDeckUnitTest
    {
        [Test()]
        public void Sort()
        {
            Deck sortDeck = new Deck();
            sortDeck.Shuffle();
            sortDeck.allCards.Sort();

            CollectionAssert.IsOrdered(sortDeck.allCards);
        }

        [Test()]
        public void Shuffle()
        {
            Deck ctrlDeck = new Deck();
            Deck shufDeck = new Deck();

            shufDeck.Shuffle();

            Assert.That(ctrlDeck.allCards, Is.EqualTo(ctrlDeck.allCards));
            Assert.That(ctrlDeck.allCards, Is.Not.EqualTo(shufDeck.allCards));
        }
    }
}
