using Microsoft.Xna.Framework;

namespace MonoEngine.Models
{
    public class Hitbox
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Hitbox(Sprite Sprite) : this((int)(Sprite.Texture.Width / Sprite.Scale.X), (int)(Sprite.Texture.Height / Sprite.Scale.Y)) { }
        public Hitbox(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public bool IsHit(Vector2 HitboxPosition, Vector2 Position)
        {
            if (Position.X > HitboxPosition.X + Width)
                return false;

            if (Position.Y > HitboxPosition.Y + Height)
                return false;

            if (Position.X < HitboxPosition.X)
                return false;

            if (Position.Y < HitboxPosition.Y)
                return false;

            return true;
        }

        public bool IsHit(Vector2 HitboxPosition, Vector2 Position, Hitbox Hitbox)
        {
            if (Position.X > HitboxPosition.X + Width)
                return false;

            if (Position.Y > HitboxPosition.Y + Height)
                return false;

            if (Position.X == Hitbox.Width && Position.Y == Hitbox.Height)
                return false;

            if (Position.X + Hitbox.Width < HitboxPosition.X)
                return false;

            if (Position.Y + Hitbox.Height < HitboxPosition.Y)
                return false;

            return true;
        }

        internal void OnSpriteResize(object sender, SpriteEventArgs e)
        {
            Width = e.Width;
            Height = e.Height;
        }
    }
}
