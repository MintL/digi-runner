using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core
{
    public class Corporation : Player
    {

        protected override int MaxClicks
        {
            get { return 3; }
        }

        public List<Server> RemoteServers { get; protected set; }

        public Corporation()
        {
            Hand = new List<Card>();
            Hand.Add(new Card());
            Hand.Add(new Card());
            Hand.Add(new Card());
            Hand.Add(new Card());

            RemoteServers = new List<Server>();
            RemoteServers.Add(new Server());
            RemoteServers.Add(new Server());
            RemoteServers.Add(new Server());
        }
    }
}
