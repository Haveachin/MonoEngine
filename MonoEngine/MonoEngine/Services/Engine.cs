using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine.Models;
using System.Collections.Generic;

namespace MonoEngine.Services
{
    public static class Engine
    {
        internal static DepictionService DepictionService;
        internal static InstanceService InstanceService;
        internal static SceneService SceneService;

        public static List<BasicObject> Instances => InstanceService.Instances;
        public static Scene ActiveScene { get; private set; }

        public static void RegisterScene(uint id, Scene scene)
            => SceneService.Scenes.Add(id, scene);

        public static void LoadScene(uint id)
        {
            if (!SceneService.Scenes.TryGetValue(id, out Scene NextScene))
                return;

            foreach (var instance in InstanceService.Instances)
            {
                instance.Dispose();
            }

            InstanceService.Instances.Clear();
            InstanceService.Instances.TrimExcess();

            NextScene.Initialize();

            ActiveScene = NextScene;
        }

        public static void Initialize(GraphicsDeviceManager graphics)
        {
            DepictionService = new DepictionService();
            InstanceService = new InstanceService();
            SceneService = new SceneService();

            Camera.Graphics = graphics;
        }

        public static void UnloadContent(ContentManager content)
        {
            foreach (var instance in InstanceService.Instances)
            {
                instance.Dispose();
            }
        }

        public static void Update(GameTime gameTime)
        {
            ActiveScene?.Update(gameTime);
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            DepictionService?.Draw(spriteBatch);
            ActiveScene?.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
