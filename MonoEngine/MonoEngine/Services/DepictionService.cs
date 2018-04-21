using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoEngine.Services
{
    internal class DepictionService
    {
        public event EventHandler<DrawingEventArgs> Drawing;

        public void Draw(SpriteBatch spriteBatch)
        {
            OnDrawing(spriteBatch);
        }

        protected virtual void OnDrawing(SpriteBatch spriteBatch)
            => Drawing?.Invoke(this, new DrawingEventArgs() { SpriteBatch = spriteBatch } );
    }

    public class DrawingEventArgs : EventArgs
    {
        public SpriteBatch SpriteBatch { get; set; }
    }
}
