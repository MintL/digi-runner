using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core.Servers
{
    public class CorporationDiscard
    {
        public List<Card> ICE { get; set; }
        public List<Card> Pile { get; set; }
        public List<Card> Upgrades { get; set; }
    }
}
