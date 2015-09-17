using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdFlame.GameSystems {
    class PhysicsSystem : GameSystem {

        public override int priority { get; } = 19;

        public PhysicsSystem() : base()
        {
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
