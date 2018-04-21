using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoEngine.Extensions
{
    public static class Texture2DExtension
    {
        public static Vector2 GetSize(this Texture2D texture)
            => new Vector2(texture.Width, texture.Height);
    }
}
