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
            List<Card> deck = GameModel.Instance.LocalPlayer.Deck;

            Card card = deck[0];

            //GameModel.Instance.LocalPlayer.OnDrawCard(card);
        }
    }
}
