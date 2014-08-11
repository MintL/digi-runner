using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Netrunner.Core;
using Microsoft.Xna.Framework.Graphics;
using Netrunner.Core.Servers;

namespace Netrunner.View
{
    public class RemoteServerView : View
    {
        private Texture2D background;
        
        // TODO: Multiple cards
        private Sprite serverSprite;

        private RemoteServer server;

        public RemoteServerView(RemoteServer server)
        {
            this.server = server;
        }

        public override void OnClicked(Point mousePosition)
        {

        }

        public void LoadContent(ContentManager content, Vector2 position)
        {
            background = content.Load<Texture2D>("card");

            Bounds = new Rectangle((int)position.X, (int)position.Y, background.Bounds.Width, background.Bounds.Height);
            
            serverSprite = new Sprite(background, new Vector2(Bounds.X, Bounds.Y), Color.LightSalmon);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Update view from server

            serverSprite.Draw(spriteBatch);
        }
    }
}
