using System;
using System.Collections.Generic;
namespace CardDeck
{
    public class Deck : IComparer<Deck.Card>
    {
        public List<Card> allCards = new List<Card>();

        public Deck()
        {
            while (this.allCards.Count < 52)
            {
                int val = (this.allCards.Count + 1) % 13;
                val = val > 0 ? val : 13;
                this.allCards.Add(new Card(this.allCards.Count < 13 ? "hearts" :
                                           this.allCards.Count < 26 ? "clubs" :
                                           this.allCards.Count < 39 ? "diamonds" : "spades"
                                          , val == 1 ? "Ace" :
                                            val == 11 ? "Jack" :
                                            val == 12 ? "Queen" :
                                            val == 13 ? "King" : val.ToString()
                                          , val));
            }
        }

        public interface Suite
        {
            string SuiteName { get; set; }
            string CardName { get; set; }
            int? CardValue { get; set; }
        }

        public class Card : Suite, IComparable
        {
            public string SuiteName { get; set; }
            public string CardName { get; set; }
            public int? CardValue { get; set; }

            public Card(string suite = null
                     , string card = null
                     , int? val = null)
            {
                this.SuiteName = suite;
                this.CardName = card;
                this.CardValue = val;
            }

            public int CompareTo(object obj)
            {
                return obj == null ? 1 :
                        this.CardValue.Value.CompareTo(((Card)obj).CardValue.Value);          
            }
        }

        public int Compare(Deck.Card a, Deck.Card b)
        {
            System.Collections.CaseInsensitiveComparer c = new System.Collections.CaseInsensitiveComparer();
            return c.Compare(a, b);
        }

        public void Shuffle()
        {
			Random r = new Random();
            for (int i = 0; i < this.allCards.Count; i++)
			{
				Card c = this.allCards[i];
				this.allCards.RemoveAt(i);
				this.allCards.Insert(r.Next(0, this.allCards.Count + 1), c);
			}
        }

        public void Print()
        {
			for (int i = 0; i < this.allCards.Count; i++)
			{
				Deck.Card c = this.allCards[i];
				Console.Write(c.SuiteName + " | " + c.CardName + " | " + c.CardValue + "\r\n");
			}    
        }
    }
}
