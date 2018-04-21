using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoEngine.Input
{
    public class KeyboardHook : BasicObject
    {
        public static Keys[] PressedKeys => Keyboard.GetState().GetPressedKeys();

        public KeyboardState PreviouseState { get; private set; }

        private Dictionary<List<Keys>, Action<object, EventArgs>> hotKeys;

        public KeyboardHook()
        {
            PreviouseState = new KeyboardState();
            hotKeys = new Dictionary<List<Keys>, Action<object, EventArgs>>();
        }

        public void AddHotKey(Action<object, EventArgs> action, params Keys[] keys) => hotKeys.Add(keys.ToList(), action);
        
        public override void Update(GameTime gameTime)
        {
            if (PressedKeys.Length <= 0)
                return;

            foreach (var hotKey in hotKeys)
            {
                int pressed = 0;

                foreach (var key in hotKey.Key)
                {
                    for (int i = 0; i < PressedKeys.Length; i++)
                    {
                        if (key == PressedKeys[i])
                            pressed++;
                    }
                }

                Console.WriteLine($"Oh! Hello, sir. Your number is " + pressed);

                if (pressed != hotKey.Key.Count)
                    return;

                hotKey.Value(this, EventArgs.Empty);
            }

            PreviouseState = Keyboard.GetState();
        }
    }
}
