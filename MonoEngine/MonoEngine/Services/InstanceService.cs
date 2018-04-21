using MonoEngine.Models;
using System.Collections.Generic;

namespace MonoEngine.Services
{
    internal class InstanceService
    {
        public List<BasicObject> Instances { get; private set; }

        public InstanceService()
        {
            Instances = new List<BasicObject>();
        }
    }
}
