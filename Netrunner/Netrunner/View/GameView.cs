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

        private int screenWidth;
        private int screenHeight;

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

            corpView = new CorporationView();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = GraphicsDevice.Viewport.Bounds.Width;
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;       

            corpView.LoadContent(Game.Content, new Rectangle(0, 0, screenWidth, screenHeight / 2));

            views = new List<View>();
            views.Add(corpView);
            
        }

        public override void Update(GameTime gameTime)
        {
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
