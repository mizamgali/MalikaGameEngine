using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using MalikaGameEngine.GameScreens;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MalikaGameEngine.GameObjects
{
    public class GameObject
    {
        public Texture2D Texture { 
            get { //при вызове текстуры работает гет тобишь возвращает текстуру с размеромҰсетҚ
                return texture;
            } set { //при создании текстуры вызывается сет
                if(value!= null)
                {
                    texture = value;
                    Size = new Vector2(value.Width, value.Height);
                }
            }
        }                              // текстура
        Texture2D texture;
        public Vector2 Position { get; set; }                               // позиция
        public Vector2 Size { get; set; }                                   // размер
        public Vector2 Origin { get; set; }                                 // центр
        public GameScreen Context { get; }                                  // контекст
        protected ContentManager _content => Context.Content;               // content manager
        public float Rotation { get; set; }                                 // угол поворота
        public Vector2 Scale { get; set; }                                  // масштаб
        public float Speed { get; set; }                                    //скорость
        public Animation Animation { get; set; }                            // текущая анимация 
        public Dictionary<string, Animation> Animations { get; set; }       // анимации
        protected Dictionary<string, Keys> _input => Context.Game.Input;    // content manager

        public GameObject(GameScreen context)
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
            Scale = Vector2.One;
            Speed = 400f;
        }

        /// <summary>
        /// Обновление.Срабатывает каждый кадр
        /// </summary>
        public virtual void Update(float elapsedTime)
        {
            Animation?.Update(elapsedTime);
        }

        /// <summary>
        /// Отрисовка.Срабатывает каждый кадр
        /// </summary>
        public virtual void Draw()
        {
            //попробует сделать это
            try { 
                Context.SpriteBatch.Draw(
                    texture,
                    Position,
                    Animation?.SpriteRectangle,
                    Color.White,
                    Rotation,
                    Origin,
                    Scale,
                    SpriteEffects.None,
                    0
                    );
            }
            catch //если не получится делет это
            {
                Texture = _content.Load<Texture2D>("GameObjects/s_TextureError");
            }
        }

        /// <summary>
        /// Проверяет сталкновение текущего объекта с получаемым объектом
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool IsCollide(GameObject gameObject)
        {
            return
                   Position.X + Size.X / 2 >= gameObject.Position.X - gameObject.Size.X / 2 &&
                   Position.X - Size.X / 2 <= gameObject.Position.X + gameObject.Size.X / 2 &&
                   Position.Y + Size.Y / 2 >= gameObject.Position.Y - gameObject.Size.Y / 2 &&
                   Position.Y - Size.Y / 2 <= gameObject.Position.Y + gameObject.Size.Y / 2;
        }
    }
}
