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

        private int deckCount;
        private int discardPileCount;

        private Sprite deckSprite;
        private Sprite discardPileSprite;

        private MainBoardController controller;
        private Player player;

        Texture2D background;
        Texture2D backgroundEmpty;

        public MainBoardView(Player player)
        {
            controller = new MainBoardController();
            this.player = player;
        }

        public override void OnClicked(Point mousePosition)
        {
            if (deckSprite.Contains(mousePosition)) {
                controller.OnDeckClicked();
            }
        }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            background = content.Load<Texture2D>("card");
            backgroundEmpty = content.Load<Texture2D>("cardEmpty");
            cardOffset = background.Bounds.Width + 10;

            Bounds = new Rectangle((int)position.X, (int)position.Y, (cardOffset) * 2, background.Bounds.Height);

            deckSprite = new Sprite(background, new Vector2(Bounds.X, Bounds.Y), Color.Green);
            discardPileSprite = new Sprite(background, new Vector2(Bounds.X + cardOffset, Bounds.Y), Color.DarkGray);

            gameFont = content.Load<SpriteFont>("gameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            deckCount = player.DeckCount;
            discardPileCount = player.DiscardPile.Count;

            if (deckCount > 0) 
                deckSprite.Texture = background;
            else 
                deckSprite.Texture = backgroundEmpty;

            deckSprite.Draw(spriteBatch);
            String text = deckCount.ToString();
            Vector2 textPos = deckSprite.Position + (new Vector2(deckSprite.Texture.Bounds.Width, deckSprite.Texture.Bounds.Height)) / 2 - 
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);

            
            if (discardPileCount > 0) 
                discardPileSprite.Texture = background;
            else 
                discardPileSprite.Texture = backgroundEmpty;

            discardPileSprite.Draw(spriteBatch);
            text = discardPileCount.ToString();
            textPos = discardPileSprite.Position + (new Vector2(discardPileSprite.Texture.Bounds.Width, discardPileSprite.Texture.Bounds.Height)) / 2 -
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);  
        }

    }
}
