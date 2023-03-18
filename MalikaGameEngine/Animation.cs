using MalikaGameEngine.GameObjects;
using Microsoft.Xna.Framework;

namespace MalikaGameEngine
{
    /// <summary>
    /// Анимация
    /// </summary>
    public class Animation
    {
        public GameObject Context;                                  //контекст
        public int SpriteCount { get; }                             //количество анимации
        public int SpriteIndex { get; set; }                        //индекс текущего спрайта
        public float Speed { get; set; }                            //скорость
        public Rectangle SpriteRectangle { get; private set; }      //прямоугольник спрайта

        private int _index;                                         //индекс анимации в спрайтбоксе
        private float _currentTime;                                 //текущее время таймера
        

        /// <summary>
        /// Конструктор анимации
        /// </summary>
        /// <param name="context">Игровой объект которому пренадлежит анимация</param>
        /// <param name="index">Индекс анимации в спрайтбоксе</param>
        /// <param name="spriteCount">Кол-во спрайтов</param>
        /// <param name="speed">Скорость</param>
        public Animation(GameObject context, int index, int spriteCount = 1, float speed = 1f)
        {
            Context = context;
            SpriteCount = spriteCount;
            SpriteIndex = 0;
            Speed = speed;
            SpriteRectangle = Rectangle.Empty;
            _index = index;
            _currentTime = 0;
        }

        /// <summary>
        /// Обнавляет анимацию
        /// </summary>
        /// <param name="elapsedTime">время прошедшее с предыдущего кадра</param>
        public void Update(float elapsedTime)
        {
            if (_currentTime >= Speed)
            {
                _currentTime = 0;
                SpriteIndex++;
                if (SpriteIndex >= SpriteCount)
                {
                    SpriteIndex = 0;
                }
            }

            SpriteRectangle = new Rectangle(SpriteIndex * (int)Context.Size.X, _index * (int)Context.Size.Y, (int)Context.Size.X, (int)Context.Size.Y);

            _currentTime += elapsedTime;
        }
    }
}
