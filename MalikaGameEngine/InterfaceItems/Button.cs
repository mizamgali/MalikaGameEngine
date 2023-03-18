using MalikaGameEngine.GameScreens;
using MalikaGameEngine.InterfaceItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MalikaGameEngine.InterfaceItems
{
    /// <summary>
    /// Кнопка
    /// </summary>
    public class Button : InterfaceItem
    {
        public Texture2D TextureHover { get; private set; }     //текстура кнопки при наведении
        public bool IsCliсked { get; private set; }             //значение нажата ли кнопка
        public bool IsHold { get; private set; }                //значение зажата ли кнопка
        public bool IsHover { get; private set; }               //значение наведен ли курсор

        public Rectangle ClickBox { get {                       //поле клика мыши
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height
                    ); } }                                     

        private MouseState _currentMouseState;                  //текущее состояние мыши
        private MouseState _previousMouseState;                 //пердыдущее состояние мыши

        public event EventHandler Click;                        //событие нажатия
        public event EventHandler Hover;                        //
        

        public Button(GameScreen context, Texture2D texture, Texture2D textureHover = null)
            : base(context)
        {
            Texture = texture;
            TextureHover = textureHover;
        }

        public Button(GameScreen context, Texture2D texture, Vector2 position, Texture2D textureHover = null) 
            : this(context, texture, textureHover)
        {
            Position = position;
        }

        public override void Update(float elapsedTime)
        {
            _previousMouseState = _currentMouseState;   
            _currentMouseState = Mouse.GetState();

            Rectangle currentMouseRectange = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
            Rectangle previousMouseRectangle = new Rectangle(_previousMouseState.X, _previousMouseState.Y, 1, 1);

            IsCliсked = false;
            IsHover = false;

            if (currentMouseRectange.Intersects(ClickBox))
            {
                IsHover = true;
                Hover.Invoke(this, new EventArgs());

                if (_currentMouseState.LeftButton == ButtonState.Pressed
                && _previousMouseState.LeftButton != ButtonState.Pressed)
                {
                    IsCliсked = true;
                    Click.Invoke(this, new EventArgs());
                }
            }

            base.Update(elapsedTime);
        }
    }
}
