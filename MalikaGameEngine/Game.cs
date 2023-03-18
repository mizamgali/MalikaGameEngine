using MalikaGameEngine.Managers;
using MalikaGameEngine.GameObjects;
using Microsoft.Xna.Framework.Input;
using Keyboard = MalikaGameEngine.Managers.Keyboard;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MalikaGameEngine.GameScreens;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System;

namespace MalikaGameEngine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch;
        public ScreenManager ScreenManager { get; }                     //мэнеджер экранов
        public Dictionary<string, Keys> Input { get; private set; }   

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenManager = new ScreenManager();
            Components.Add(ScreenManager);
        }

        protected override void Initialize()
        {
            base.Initialize();

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Input = new Dictionary<string, Keys>();
            Dictionary<string, string> input = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("Input.json"));
            foreach(var pair in input)
            {
                Input.Add(pair.Key, Enum.Parse<Keys>(pair.Value));
            }
        }
        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();          

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}