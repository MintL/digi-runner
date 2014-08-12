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
            if (GameModel.Instance.LocalPlayer is Corporation) {
                if (GameModel.Instance.Corporation.Deck.CardCount > 0) {
                    Card card = new Card(Card.Types.HIDDEN);
                    GameModel.Instance.Corporation.OnDrawCard(card);
                }
            }
        }
    }
}
