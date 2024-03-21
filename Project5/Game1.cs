using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Project5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        List<Player> players = new List<Player>();
        List<CollisionDetector> playerFloorDetections = new List<CollisionDetector>();
        Rectangle floor = new Rectangle(0, 800, 9999, 20);
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 1000;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.sb = new SpriteBatch(GraphicsDevice);
            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData<Color>(new Color[] { Color.IndianRed });

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState cursor = Mouse.GetState();
            if (cursor.LeftButton == ButtonState.Pressed)
            {
                Trace.WriteLine("Clicked");
                Player p = new Player(cursor.X, cursor.Y);
                players.Add(p);
                CollisionDetector cd = new CollisionDetector(p.floorDetector, floor);
                playerFloorDetections.Add(cd);
            }

            // TODO: Add your update logic here

            for (int i = 0; i < players.Count; i++)
            {
                playerFloorDetections[i].Update(players[i].floorDetector, floor);
                players[i].Update(playerFloorDetections[i].Collision(), floor);
            }

            Globals.SET_DT(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.sb.Begin();
            Globals.sb.Draw(Globals.pixel, floor, Color.White);

            for (int i = 0; i < players.Count; i++)
            {
                players[i].Draw();
            }

            Globals.sb.End();

            base.Draw(gameTime);
        }
    }
}
