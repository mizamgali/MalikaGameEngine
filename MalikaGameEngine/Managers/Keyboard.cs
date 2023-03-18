using Microsoft.Xna.Framework.Input;
using MonoGameKeyboard = Microsoft.Xna.Framework.Input.Keyboard;
using System;
using System.Linq;

namespace MalikaGameEngine.Managers
{
    /// <summary>
    /// Взаимодействие с клавиатурой
    /// </summary>
    public static class Keyboard
    {
        private static KeyboardState _previousKeyboardState;                                       //Предыдущее состояние клавиатуры
        private static KeyboardState _currentKeyboardState = MonoGameKeyboard.GetState();          //Нынешнее состояние клавиатуры

        /// <summary>
        /// Проверяет зажата ли клавиша
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyDown(Keys key)
        {
            return MonoGameKeyboard.GetState().IsKeyDown(key);
        }
        /// <summary>
        /// Проверяет нажата ли клавиша
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyPressed(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        }
        /// <summary>
        /// Проверят отпустили ли клавишу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyUp(Keys key)
        {
            return MonoGameKeyboard.GetState().IsKeyUp(key);
        }
        /// <summary>
        /// Обнавляет предыдущее состояние клавиатуры
        /// </summary>
        public static void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = MonoGameKeyboard.GetState();
        }
    }
}