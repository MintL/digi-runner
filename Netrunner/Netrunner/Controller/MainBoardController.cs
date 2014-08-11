using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Netrunner.Core;

namespace Netrunner.Presenter
{
    public class MainBoardController
    {
        private GameModel model;

        public MainBoardController()
        {
            this.model = GameModel.Instance;
        }

        public void OnDeckClicked()
        {
            int deckCount = model.LocalPlayer.DeckCount;
            List<Card> hand = model.LocalPlayer.Hand;

            if (deckCount > 0) {
                model.Server.DrawCard();

                
            }

        }
    }
}
