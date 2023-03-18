using MalikaGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalikaGameEngine.InterfaceItems
{
    public class InterfaceItem
    {
        public Texture2D Texture { get; set; }                      // текстура
        public Vector2 Position { get; set; }                       // позиция
        public Vector2 Size { get; set; }                           // размер
        protected ContentManager _content => Context.Content;       //content manager
        public Vector2 Origin { get; set; }                         // центр
        public GameScreen Context { get; }                          // контекст
        public float Rotation { get; set; }                         // угол поворота
        public float Scale { get; set; }                            // масштаб

        public InterfaceItem(GameScreen context)
        {
            Context = context;
            Init();
        }

        /// <summary>
        /// Инициализация.Срабатывает один раз
        /// </summary>
        public virtual void Init()
        {
            Origin = new Vector2(Size.X / 2, Size.Y / 2);
            Rotation = 0;
            Scale = 1;
        }

        /// <summary>
        /// Обновление.Срабатывает каждый кадр
        /// </summary>
        public virtual void Update(float elapsedTime)
        {
        }

        /// <summary>
        /// Отрисовка.Срабатывает каждый кадр
        /// </summary>
        public void Draw()
        {
            Context.SpriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                Rotation,
                Origin,
                Scale,
                SpriteEffects.None,
                0
                ); ;
        }
    }
}
