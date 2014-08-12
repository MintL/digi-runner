using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netrunner.Core;
using Netrunner.Core.Servers;

namespace Netrunner.View
{
    public class CorporationView : View
    {
        Corporation corp;

        private ContentManager content;
        private Vector2 corpDeckPos;
        private int cardWidth;

        private CorpDeckView deckView;
        private CorpDiscardView discardView;
        private List<RemoteServerView> remoteServerViews;
        private HandView handView;

        private int serverOffsetX = 50;

        public CorporationView()
        {
            corp = GameModel.Instance.Corporation;

            deckView = new CorpDeckView(corp);
            discardView = new CorpDiscardView(corp);
            handView = new HandView(corp);
        }

        public void LoadContent(ContentManager content, Rectangle bounds)
        {
            this.content = content;
            Bounds = bounds;
            cardWidth = content.Load<Texture2D>("card").Width;

            corpDeckPos = new Vector2(Bounds.Width / 2 - cardWidth, Bounds.Height / 2);
            deckView.LoadContent(content, corpDeckPos);
            discardView.LoadContent(content, corpDeckPos + Vector2.UnitX * (deckView.Bounds.Width + serverOffsetX));
            handView.LoadContent(content, corpDeckPos + Vector2.UnitX * 2.1f * (deckView.Bounds.Width + serverOffsetX));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            deckView.Draw(spriteBatch);
            discardView.Draw(spriteBatch);

            List<RemoteServer> remoteServers = corp.RemoteServers;
            remoteServerViews = new List<RemoteServerView>();
            for (int i = 0; i < remoteServers.Count; i++)
			{
			    RemoteServerView view = new RemoteServerView(remoteServers[i]);

                view.LoadContent(content, corpDeckPos - Vector2.UnitX * (cardWidth + serverOffsetX) * (i + 1));
                view.Draw(spriteBatch);

                remoteServerViews.Add(view);
			}
            handView.Draw(spriteBatch);
        }

        public override void OnClicked(Point mouse)
        {
            
        }
    }
}
