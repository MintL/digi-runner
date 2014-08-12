using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Netrunner.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Netrunner.View
{
    class CorpDiscardView : View
    {
        private SpriteFont gameFont;

        private int discardPileCount;

        private Sprite discardPileSprite;

        private Corporation corp;

        Texture2D background;
        Texture2D backgroundEmpty;
        
        public CorpDiscardView(Corporation corp)
        {
            //controller = new MainBoardController();
            this.corp = corp;
        }

        public override void OnClicked(Point mousePosition)
        {
            if (discardPileSprite.Contains(mousePosition)) {
                //controller.OnDeckClicked();
            }
        }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            background = content.Load<Texture2D>("card");
            backgroundEmpty = content.Load<Texture2D>("cardEmpty");

            Bounds = new Rectangle((int)position.X, (int)position.Y, background.Bounds.Width, background.Bounds.Height);

            discardPileSprite = new Sprite(background, new Vector2(Bounds.X, Bounds.Y), Color.Green);

            gameFont = content.Load<SpriteFont>("gameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            discardPileCount = corp.Discard.Pile.Count;

            if (discardPileCount > 0) 
                discardPileSprite.Texture = background;
            else 
                discardPileSprite.Texture = backgroundEmpty;

            discardPileSprite.Draw(spriteBatch);
            String text = discardPileCount.ToString();
            Vector2 textPos = discardPileSprite.Position + (new Vector2(discardPileSprite.Texture.Bounds.Width, discardPileSprite.Texture.Bounds.Height)) / 2 - 
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);

        }
    }
}
