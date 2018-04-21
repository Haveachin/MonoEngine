using MonoEngine.Models;
using System.Collections.Generic;

namespace MonoEngine.Services
{
    internal class SceneService
    {
        public Dictionary<uint, Scene> Scenes { get; private set; }

        public SceneService()
        {
            Scenes = new Dictionary<uint, Scene>();
        }
    }
}
