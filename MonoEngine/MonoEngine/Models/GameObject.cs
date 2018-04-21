using Microsoft.Xna.Framework;
using MonoEngine.Services;
using System;

namespace MonoEngine.Models
{
    public abstract class GameObject : IDisposable
    {
        private Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;

                if (Sprite != null)
                    Sprite.Position = _position;
            }
        }

        private Sprite _sprite;

        public Sprite Sprite
        {
            get => _sprite;
            set
            {
                _sprite = value;
                _sprite.Position = Position;
            }
        }

        public Depth Depth { get; set; }

        public GameObject(Vector2 position)
        {
            Position = position;

            Engine.InstanceService.Instances.Add(this);
        }

        public GameObject(Vector2 position, Sprite sprite) : this(position)
        {
            Sprite = sprite;
        }

        public GameObject(Vector2 position, Sprite sprite, Depth depth) : this(position, sprite)
        {
            Depth = depth;
        }

        public GameObject(float x, float y) : this(new Vector2(x, y)) { }
        public GameObject(float x, float y, Sprite sprite) : this(new Vector2(x, y), sprite) { }
        public GameObject(float x, float y, Sprite sprite, Depth depth) : this(new Vector2(x, y), sprite, depth) { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Dispose() => this?.Sprite.Dispose();
    }
}
