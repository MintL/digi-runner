using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core
{
    public class Server
    {
        public ICE ICEHead { get; set; }

        public List<Card> Upgrades { get; set; }

        public int Type { get; protected set; }
    }
}
