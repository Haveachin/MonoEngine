using MonoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine.Services
{
    internal class InstanceService
    {
        public List<GameObject> Instances { get; private set; }

        public InstanceService()
        {
            Instances = new List<GameObject>();
        }
    }
}
