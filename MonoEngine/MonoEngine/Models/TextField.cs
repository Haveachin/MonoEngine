using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Models.Graphics;
using MonoEngine.Services;

namespace MonoEngine.Models
{
    public class TextField : Depiction
    {
        private SpriteFont _spriteFont;
        public SpriteFont SpriteFont
        {
            get => _spriteFont;
            set => _spriteFont = value ?? _spriteFont;
        }

        public string Text { get; set; }

        public TextField(Vector2 position, SpriteFont spriteFont) : base(position)
        {
            SpriteFont = spriteFont;
            Color = Color.Black;
        }

        public TextField(float x, float y, SpriteFont spriteFont) : this(new Vector2(x, y), spriteFont) { }

        public override void Draw(object sender, DrawingEventArgs e)
        {
            if (Visible && _spriteFont != null)
                e.SpriteBatch.DrawString(_spriteFont, Text, Position, Color, _rotation, Origin, Scale, Effect, Depth);
        }

        public override void Dispose()
        {
            Text = "";
            _spriteFont = null;

            base.Dispose();
        }
    }
}
