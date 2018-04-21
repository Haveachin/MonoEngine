using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Services;

namespace MonoEngine.Models.Graphics
{
    internal interface IDepictionable
    {
        Vector2 Position { get; set; }

        Vector2 Origin { get; set; }

        Color Color { get; set; }

        Vector2 Scale { get; set; }

        float Rotation { get; set; }

        Depth Depth { get; set; }

        SpriteEffects Effect { get; set; }
        
        void Draw(object sender, DrawingEventArgs e);
    }
}
