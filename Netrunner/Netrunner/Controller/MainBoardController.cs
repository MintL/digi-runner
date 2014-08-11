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
            List<Card> deck = model.LocalPlayer.Deck;
            List<Card> hand = model.LocalPlayer.Hand;

            if (deck.Count > 0) {
                model.Server.DrawCard();

                
            }

        }
    }
}
