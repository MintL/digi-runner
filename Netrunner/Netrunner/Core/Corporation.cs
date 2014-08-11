using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Netrunner.Core.Servers;

namespace Netrunner.Core
{
    public class Corporation : Player
    {

        protected override int MaxClicks
        {
            get { return 3; }
        }

        public List<RemoteServer> RemoteServers { get; protected set; }
        public CorporationDeck CorpDeck { get; protected set; }
        public CorporationDiscard CorpDiscard { get; protected set; }

        public Corporation()
        {
            Hand = new List<Card>();
            Hand.Add(new Card(Card.Types.HIDDEN));
            Hand.Add(new Card(Card.Types.HIDDEN));
            Hand.Add(new Card(Card.Types.HIDDEN));
            Hand.Add(new Card(Card.Types.HIDDEN));

            RemoteServers = new List<RemoteServer>();
            RemoteServers.Add(new RemoteServer());
            RemoteServers.Add(new RemoteServer());

            CorpDeck = new CorporationDeck();
            CorpDiscard = new CorporationDiscard();
        }
    }
}
