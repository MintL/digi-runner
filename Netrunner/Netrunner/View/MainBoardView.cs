using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Netrunner.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Netrunner.Presenter;

namespace Netrunner.View
{
    public class MainBoardView : View
    {
        private SpriteFont gameFont;
        private int cardOffset;

        private List<Card> deck;
        private List<Card> discardPile;

        private Sprite deckSprite;
        private Sprite discardPileSprite;

        private MainBoardController controller;

        public MainBoardView()
        {
            controller = new MainBoardController();
        }

        public void Update(List<Card> deck, List<Card> discardPile)
        {
            //this.deckSprite.Position = new Vector2(Bounds.X, Bounds.Y);
            //this.discardPileSprite.Position = ;

            

            this.deck = deck;
            this.discardPile = discardPile;
            
        }

        public override void OnClicked(Point mousePosition)
        {
            if (deckSprite.Contains(mousePosition)) {
                controller.OnDeckClicked();
            }
        }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            Texture2D background = content.Load<Texture2D>("card");
            cardOffset = background.Bounds.Width + 10;

            Bounds = new Rectangle((int)position.X, (int)position.Y, (cardOffset) * 2, background.Bounds.Height);

            deckSprite = new Sprite(background, new Vector2(Bounds.X, Bounds.Y), Color.Green);
            discardPileSprite = new Sprite(background, new Vector2(Bounds.X + cardOffset, Bounds.Y), Color.Yellow);

            gameFont = content.Load<SpriteFont>("gameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            if (deck.Count > 0) {
                deckSprite.Draw(spriteBatch);
            }
            String text = deck.Count.ToString();
            Vector2 textPos = deckSprite.Position + (new Vector2(deckSprite.Texture.Bounds.Width, deckSprite.Texture.Bounds.Height)) / 2 - 
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);

            
            if (discardPile.Count > 0) {
                discardPileSprite.Draw(spriteBatch);
            }
            text = discardPile.Count.ToString();
            textPos = discardPileSprite.Position + (new Vector2(discardPileSprite.Texture.Bounds.Width, discardPileSprite.Texture.Bounds.Height)) / 2 -
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);  
        }

    }
}
