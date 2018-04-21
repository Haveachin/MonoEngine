using Microsoft.Xna.Framework;
using MonoEngine.Services;

namespace MonoEngine.Models
{
    public abstract class BasicObject
    {
        public BasicObject()
        {
            Engine.InstanceService.Instances.Add(this);
        }

        public abstract void Update(GameTime gameTime);
    }
}
