using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using MonoEngine.Services;
using MonoEngine.Models.Graphics;

namespace MonoEngine.Models
{
    public class Sprite : Depiction, IDisposable
    {
        private Texture2D _texture;
        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value ?? _texture;
        }

        public Hitbox Hitbox { get; private set; }

        public event EventHandler<SpriteEventArgs> SpriteResize;

        protected virtual void OnSpriteResize() =>
            SpriteResize?.Invoke(this, new SpriteEventArgs() { Width = (int)(Scale.X * Texture.Width), Height = (int)(Scale.Y * Texture.Height), Scale = Scale });

        public Sprite(Vector2 position, Texture2D texture) : base(position)
        {
            Texture = texture;
            Hitbox = new Hitbox(this);

            this.SpriteResize += Hitbox.OnSpriteResize;
        }

        public Sprite(float x, float y, Texture2D texture) : this(new Vector2(x, y), texture) { }

        public override void Draw(object sender, DrawingEventArgs e)
        {
            if (Visible && _texture != null)
                e.SpriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, Scale, Effect, Depth);
        }

        public void Dispose() => this?.Texture.Dispose();
    }

    public class SpriteEventArgs : EventArgs
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Scale { get; set; }
    }
}
