using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core
{
    public abstract class Player
    {
        protected abstract int MaxClicks { get; }

        #region Properties

        public int Money { get; protected set; }
        public int Clicks { get; protected set; }
        public int VictoryPoints { get; protected set; }
        public int Tags { get; protected set; }

        public List<Card> Deck { get; protected set; }
        public List<Card> DiscardPile { get; protected set; }
        public List<Card> Hand { get; protected set; }

        #endregion


        public Player()
        {
            Deck = new List<Card>();
            for (int i = 0; i < 10; i++) {
                Deck.Add(new Card());
            }

            DiscardPile = new List<Card>();
        }
    }
}
