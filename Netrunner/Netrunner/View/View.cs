using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Netrunner.View
{
    public abstract class View
    {
        public Rectangle Bounds { get; set; }

        public abstract void OnClicked(Point mouse);
    }
}
