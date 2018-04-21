using Microsoft.Xna.Framework;
using MonoEngine.Extensions;
using System;

namespace MonoEngine.Models
{
    public class Hitbox
    {
        private Vector2 _positon;
        public Vector2 Position
        {
            get => _positon;
            set
            {
                if (Sprite != null)
                {
                    value -= Sprite.Origin * Sprite.Scale;
                }

                _positon = value;
            }
        }

        public Sprite Sprite { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Vector2 Size
        {
            get => new Vector2(Width, Height);
            set
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
        }

        public Hitbox(Sprite sprite) : this(sprite.Position, sprite) { }
        public Hitbox(Vector2 position, Sprite sprite) : this(position - sprite.Origin, (int)(sprite.Texture.Width / sprite.Scale.X), (int)(sprite.Texture.Height / sprite.Scale.Y))
        {
            Sprite = sprite;
        }
        public Hitbox(Vector2 position, int width, int height)
        {
            Position = position;

            Width = width;
            Height = height;
        }
        public Hitbox(float x, float y, Sprite sprite) : this(new Vector2(x, y), sprite) { }
        public Hitbox(float x, float y, int width, int height) : this(new Vector2(x, y), width, height) { }

        public bool IsHit(Vector2 position)
        {
            if (position.X > Position.X + Width)
                return false;

            if (position.Y > Position.Y + Height)
                return false;

            if (position.X < Position.X)
                return false;

            if (position.Y < Position.Y)
                return false;

            return true;
        }

        public bool IsHit(Hitbox Hitbox)
        {
            if (Hitbox.Position.X > Position.X + Width)
                return false;

            if (Hitbox.Position.Y > Position.Y + Height)
                return false;

            if (Hitbox.Position.X == Hitbox.Width && Hitbox.Position.Y == Hitbox.Height)
                return false;

            if (Hitbox.Position.X + Hitbox.Width < Position.X)
                return false;

            if (Hitbox.Position.Y + Hitbox.Height < Position.Y)
                return false;

            return true;
        }

        public void OnSpriteResize(object sender, EventArgs e)
        {
            var sprite = sender as Sprite;

            Size = sprite.Texture.GetSize() * sprite.Scale;
            Position = sprite.Position; // Fixes scaling bug
        }

        public void OnSpriteReposition(object sender, EventArgs e)
        {
            Position = (sender as Sprite).Position;
        }
    }
}
