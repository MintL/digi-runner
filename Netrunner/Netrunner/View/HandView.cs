using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Netrunner.Core;

namespace Netrunner.View
{
    public class HandView : View
    {
        private Texture2D background;
        private int cardOffset;
        private Player player;

        public HandView(Player player)
        {
            this.player = player;
        }

        public List<Card> Cards { get; protected set; }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            background = content.Load<Texture2D>("card");
            cardOffset = background.Bounds.Width + 5;

            int count = player.Hand.Count;
            Bounds = new Rectangle((int)position.X, (int)position.Y, background.Bounds.Width + count * cardOffset, background.Bounds.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Cards = player.Hand;
            Rectangle bounds = Bounds;
            bounds.Width = background.Bounds.Width + Cards.Count * cardOffset;
            Bounds = bounds;

            for (int i = 0; i < Cards.Count; i++) {
                spriteBatch.Draw(background, new Vector2(Bounds.X + i * cardOffset, Bounds.Y), Color.White);
            }
                
        }

        public override void OnClicked(Point mouse)
        {

        }
    }
}
