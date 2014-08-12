using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Netrunner.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Netrunner.Controller;

namespace Netrunner.View
{
    public class CorpDeckView : View
    {
        private SpriteFont gameFont;

        private int deckCount;

        private Sprite deckSprite;

        private DeckController controller;
        private Corporation corp;

        Texture2D background;
        Texture2D backgroundEmpty;
        
        public CorpDeckView(Corporation corp)
        {
            controller = new DeckController();
            this.corp = corp;
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

            Bounds = new Rectangle((int)position.X, (int)position.Y, background.Bounds.Width, background.Bounds.Height);

            deckSprite = new Sprite(background, new Vector2(Bounds.X, Bounds.Y), Color.Green);

            gameFont = content.Load<SpriteFont>("gameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            deckCount = corp.DeckCount;

            if (deckCount > 0) 
                deckSprite.Texture = background;
            else 
                deckSprite.Texture = backgroundEmpty;

            deckSprite.Draw(spriteBatch);
            String text = deckCount.ToString();
            Vector2 textPos = deckSprite.Position + (new Vector2(deckSprite.Texture.Bounds.Width, deckSprite.Texture.Bounds.Height)) / 2 - 
                gameFont.MeasureString(text) / 2;
            spriteBatch.DrawString(gameFont, text, textPos, Color.White);

        }

    }
}
