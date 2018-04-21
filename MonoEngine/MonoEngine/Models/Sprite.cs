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

        public override Vector2 Position
        {
            get => base.Position;
            set
            {
                base.Position = value;
                OnSpriteReposition();
            }
        }

        public override Vector2 Scale
        {
            get => base.Scale;
            set
            {
                base.Scale = value;
                OnSpriteResize();
            }
        }

        public override Vector2 Origin
        {
            get => base.Origin;
            set
            {
                base.Origin = value;
                OnSpriteReposition();
            }
        }

        public Hitbox Hitbox { get; private set; }

        public event EventHandler SpriteResize;
        public event EventHandler SpriteReposition;

        protected virtual void OnSpriteResize()
            => SpriteResize?.Invoke(this, EventArgs.Empty);

        protected virtual void OnSpriteReposition()
            => SpriteReposition?.Invoke(this, EventArgs.Empty);

        public Sprite(Vector2 position, Texture2D texture) : base(position)
        {
            Texture = texture;
            Hitbox = new Hitbox(this);

            this.SpriteResize += Hitbox.OnSpriteResize;
            this.SpriteReposition += Hitbox.OnSpriteReposition;
        }

        public Sprite(float x, float y, Texture2D texture) : this(new Vector2(x, y), texture) { }

        public override void Draw(object sender, DrawingEventArgs e)
        {
            if (Visible && _texture != null)
                e.SpriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, Scale, Effect, Depth);
        }

        public override void Dispose()
        {
            Hitbox = null;
            _texture = null;

            base.Dispose();
        }
    }
}
