using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core.Servers
{
    public class CorporationDeck
    {
        public List<Card> ICE { get; set; }
        public int CardCount { get; set; }
        public List<Card> Upgrades { get; set; }

        public CorporationDeck()
        {
            ICE = new List<Card>();
            CardCount = 10;
            Upgrades = new List<Card>();
        }
    }
}
