using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Netrunner.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Netrunner.View
{
    public class RemoteServersView : View
    {
        private List<Server> servers;
        private int xOffset;
        private Texture2D background;

        private List<Sprite> serverSprites;

        public RemoteServersView()
        {

        }

        public void Update(List<Server> servers)
        {
            this.servers = servers;
            Bounds = new Rectangle(Bounds.X, Bounds.Y, xOffset * servers.Count, background.Bounds.Height);

            if (serverSprites == null)
                serverSprites = new List<Sprite>();
            else
                serverSprites.Clear();

            for (int i = 0; i < servers.Count; i++) {
                Sprite serverSprite = new Sprite(background, new Vector2(Bounds.X + xOffset * i, Bounds.Y), Color.LightSalmon);
                serverSprites.Add(serverSprite);
            }
        }

        public override void OnClicked(Point mousePosition)
        {
            
        }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            background = content.Load<Texture2D>("card");
            xOffset = -background.Bounds.Width - 50;

            Bounds = new Rectangle((int)position.X, (int)position.Y, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (var serverSprite in serverSprites) {
                serverSprite.Draw(spriteBatch);
            }
        }
    }
}
