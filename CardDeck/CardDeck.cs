using System;
namespace CardDeck
{
    public class CardDeck
    {
        public static void Main(string[] args)
        {
            Deck d = new Deck();

            d.allCards.Sort();
            d.Print();
            d.Shuffle();
            d.Print();

            Console.ReadLine();
        }
    }
}
