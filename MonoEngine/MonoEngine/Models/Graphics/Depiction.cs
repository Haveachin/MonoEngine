using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Services;
using System;

namespace MonoEngine.Models.Graphics
{
    public abstract class Depiction : IDepictionable
    {
        public Vector2 Position { get; set; }

        public Vector2 Origin { get; set; }

        public Color Color { get; set; }

        public Vector2 Scale { get; set; }

        protected float _rotation;
        public float Rotation
        {
            get => (float)(_rotation * 180 / Math.PI);
            set => _rotation = (float)(((value > 360) ? value - 360 : (value < 0) ? value + 360 : value) * 2 * Math.PI / 360);
        }
        
        public Depth Depth { get; set; }

        public SpriteEffects Effect { get; set; } = SpriteEffects.None;

        public Depiction(Vector2 position)
        {
            Position = position;
            Origin = Vector2.Zero;
            Color = Color.White;
            Scale = Vector2.One;
            Rotation = 0;
            Depth = 0;

            Engine.DepictionService.Drawing += Draw;
        }

        public Depiction(float x, float y) : this(new Vector2(x, y)) { }

        public abstract void Draw(object sender, DrawingEventArgs e);
    }
}
