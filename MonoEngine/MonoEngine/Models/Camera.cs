using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Models
{
    public class Camera
    {
        public static GraphicsDeviceManager Graphics { get; internal set; }
        
        public Vector2 Position
        {
            get => new Vector2(Graphics.GraphicsDevice.Viewport.X, Graphics.GraphicsDevice.Viewport.Y);
            set
            {
                Graphics.GraphicsDevice.Viewport = new Viewport((int)value.X, (int)value.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public Vector2 Size { get; set; }

        public Camera(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public Camera(float x, float y, Vector2 size) : this(new Vector2(x, y), size) { }
        public Camera(float x, float y, float width, float height) : this(new Vector2(x, y), new Vector2(width, height)) { }
    }
}
