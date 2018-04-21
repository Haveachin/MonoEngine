using System;
using Microsoft.Xna.Framework;
using MonoEngine.Services;

namespace MonoEngine.Models
{
    public abstract class BasicObject : IDisposable
    {
        public BasicObject()
        {
            Engine.InstanceService.Instances.Add(this);
        }

        public virtual void Dispose() { }
    }
}
