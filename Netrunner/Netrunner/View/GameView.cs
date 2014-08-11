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
        private int height;

        private HandView localHand;
        private HandView remoteHand;

        private CorporationView corpView;

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

            corpView = new CorporationView();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            width = GraphicsDevice.Viewport.Bounds.Width;
            height = GraphicsDevice.Viewport.Bounds.Height;

            localHand.LoadContent(Game.Content);
            remoteHand.LoadContent(Game.Content);            

            corpView.LoadContent(Game.Content, new Rectangle(0, 0, width, height / 2));

            views = new List<View>();
            views.Add(corpView);
            
        }

        public override void Update(GameTime gameTime)
        {
            Player localPlayer = model.LocalPlayer;
            Player remotePlayer = model.RemotePlayer;
            localHand.Cards = localPlayer.Hand;
            remoteHand.Cards = remotePlayer.Hand;

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

            corpView.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
