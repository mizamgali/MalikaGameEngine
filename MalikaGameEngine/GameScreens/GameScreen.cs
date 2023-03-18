using MalikaGameEngine.GameObjects;
using MalikaGameEngine.InterfaceItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MalikaGameEngine.GameScreens
{
    public class GameScreen : MonoGame.Extended.Screens.GameScreen
    {
        public new Game Game => (Game)base.Game;
        public SpriteBatch SpriteBatch => Game.SpriteBatch;
        public Texture2D Background { get; set; }
        public OrthographicCamera Camera { get; set; }   //камера
        public Dictionary<string, GameObject> GameObjects {get; private set;} = new Dictionary<string, GameObject>();
        public Dictionary<string, InterfaceItem> InterfaceItems { get; private set; } = new Dictionary<string, InterfaceItem>();
        protected string? _level;
        protected int[,] _intGrid;
        protected List<Entity> _entities;

        public GameScreen(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            if (_level != null)
            {
                Background = Texture2D.FromFile(GraphicsDevice, $@"Levels\{_level}\background.png");
                _entities = JsonSerializer.Deserialize<List<Entity>>(File.ReadAllText($@"Levels\{_level}\entities.json"));

                string[] intGridLines = File.ReadAllLines($@"Levels\{_level}\intGrid.csv");
                _intGrid = new int[intGridLines.Length, intGridLines[0].Length / 2];
                for (int i = 0; i < intGridLines.Length; i++)
                {
                    for (int j = 0; j < intGridLines.Length / 2; j++)
                    {
                        string[] y = intGridLines[i].Split(","); 
                        _intGrid[i, j] = Convert.ToInt32(y[j]);
                    }
                }
            }
            Camera = new OrthographicCamera(GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            foreach(GameObject gameObject in GameObjects.Values)
            {
                gameObject.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            foreach (InterfaceItem interfaceItem in InterfaceItems.Values)
            {
                interfaceItem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            SpriteBatch.Begin(transformMatrix: Camera.GetViewMatrix());

            SpriteBatch.Draw(Background, Vector2.Zero, Color.White);

            foreach (GameObject gameObject in GameObjects.Values)
            {
                gameObject.Draw();
            }
            foreach (InterfaceItem interfaceItem in InterfaceItems.Values)
            {
                interfaceItem.Draw();
            }

            SpriteBatch.End();
        }
    }
}