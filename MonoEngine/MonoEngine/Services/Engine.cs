using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Models;
using System.Collections.Generic;

namespace MonoEngine.Services
{
    /// <summary>
    /// AES: Automated Engine Services
    /// </summary>
    public static class Engine
    {
        internal static DepictionService DepictionService;
        internal static InstanceService InstanceService;
        internal static TimeService TimeService;

        public static List<GameObject> Instances => InstanceService.Instances;

        public static void Initialize()
        {
            DepictionService = new DepictionService();
            InstanceService = new InstanceService();
            TimeService = new TimeService();
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
            TimeService.Update(gameTime);
            DepictionService.Draw(spriteBatch);
        }
    }
}
