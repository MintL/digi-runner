using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Netrunner.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Netrunner.View
{
    public class GameView : DrawableGameComponent
    {
        private GameModel model;
        private SpriteBatch spriteBatch;

        private int width;

        private HandView localHand;
        private HandView remoteHand;

        private MainBoardView localMainBoard;
        private MainBoardView remoteMainBoard;

        private RemoteServersView remoteServers;

        private List<View> views;

        private MouseState oldMouseState;
        private MouseState mouseState;

        public GameView(Game game)
            : base(game)
        {  
        }

        public override void Initialize()
        {
            model = GameModel.Instance;
            

            localHand = new HandView();
            remoteHand = new HandView();

            localMainBoard = new MainBoardView();
            remoteMainBoard = new MainBoardView();

            remoteServers = new RemoteServersView();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            width = GraphicsDevice.Viewport.Bounds.Width;

            localHand.LoadContent(Game.Content);
            remoteHand.LoadContent(Game.Content);
            localMainBoard.LoadContent(Game.Content, new Vector2((3 * width / 4), 860));
            remoteMainBoard.LoadContent(Game.Content, new Vector2((width / 8), 60));
            remoteServers.LoadContent(Game.Content, new Vector2(500, 860));

            views = new List<View>();
            //views.Add(localHand);
            //views.Add(remoteHand);
            views.Add(localMainBoard);
            views.Add(remoteMainBoard);
            views.Add(remoteServers);
            
        }

        public override void Update(GameTime gameTime)
        {
            Player localPlayer = model.LocalPlayer;
            Player remotePlayer = model.RemotePlayer;
            localHand.Cards = localPlayer.Hand;
            remoteHand.Cards = remotePlayer.Hand;

            localMainBoard.Update(localPlayer.Deck, localPlayer.DiscardPile);
            remoteMainBoard.Update(remotePlayer.Deck, remotePlayer.DiscardPile);

            if (localPlayer is Corporation) {
                Corporation corp = (Corporation)localPlayer;
                remoteServers.Update(corp.RemoteServers);
            }

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed) {
                Point mousePosition = new Point(mouseState.X, mouseState.Y);
                foreach (View view in views) {
                    if (view.Bounds.Contains(mousePosition)) {
                        view.OnClicked(mousePosition);
                    }
                }
            }
            
            oldMouseState = mouseState;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Begin();

            localHand.Draw(new Vector2((width / 2) - (localHand.Width / 2), 860), spriteBatch);
            remoteHand.Draw(new Vector2((width / 2) - (remoteHand.Width / 2), 60), spriteBatch);

            localMainBoard.Draw(spriteBatch);
            remoteMainBoard.Draw(spriteBatch);

            remoteServers.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
