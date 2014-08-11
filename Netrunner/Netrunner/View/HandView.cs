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

        public int Width
        {
            get
            {
                if (background != null && Cards != null) {
                    return (cardOffset) * Cards.Count;
                }
                return 0;
            }
        }

        public HandView() { }

        public List<Card> Cards { get; set; }

        public void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("card");
            cardOffset = 9 * background.Bounds.Width / 10;
        }

        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Cards.Count; i++) {
                spriteBatch.Draw(background, new Vector2(position.X + i * cardOffset, position.Y), Color.White);
            }
                
        }

        public override void OnClicked(Point mouse)
        {
            throw new NotImplementedException();
        }
    }
}
