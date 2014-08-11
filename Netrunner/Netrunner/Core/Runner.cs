using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netrunner.Core
{
    public class Runner : Player
    {

        protected override int MaxClicks
        {
            get { return 4; }
        }

        public Runner()
        {
            Hand = new List<Card>();
        }
    }
}
