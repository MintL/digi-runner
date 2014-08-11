using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core
{
    public class Card
    {
        public enum Types { IDENTTTY, ICE, ASSET, AGENDA, UPGRADE, OPERATION, RESOURCE, HARDWARE, PROGRAM, EVENT, HIDDEN }

        public Types Type { get; set; }

        public Card(Types type) 
        {
            Type = type;
        }
    }
}
