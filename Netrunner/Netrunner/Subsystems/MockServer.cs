using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Netrunner.Core;

namespace Netrunner.Subsystems
{
    class MockServer : IServer
    {
        public void DrawCard()
        {
            Card card = new Card();

            GameModel.Instance.LocalPlayer.OnDrawCard(card);
        }
    }
}
