using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Netrunner.View
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }

        public Sprite(Texture2D texture, Vector2 position)
            : this(texture, position, Color.White) 
        { }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            this.Texture = texture;
            this.Position = position;
            this.Color = color;
        }

        public bool Contains(Point point)
        {
            return (new Rectangle((int)Position.X, (int)Position.Y, Texture.Bounds.Width, Texture.Bounds.Height).Contains(point));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }
    }
}
