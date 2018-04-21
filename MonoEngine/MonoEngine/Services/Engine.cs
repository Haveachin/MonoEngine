using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Models;
using System.Collections.Generic;

namespace MonoEngine.Services
{
    public static class Engine
    {
        internal static DepictionService DepictionService;
        internal static InstanceService InstanceService;

        public static List<BasicObject> Instances => InstanceService.Instances;

        public static void Initialize()
        {
            DepictionService = new DepictionService();
            InstanceService = new InstanceService();
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var instance in InstanceService.Instances)
            {
                instance.Update(gameTime);
            }
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            DepictionService.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
