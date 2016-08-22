using System;

namespace ColdFlame.GameSystems
{
    internal class PhysicsSystem : GameSystem
    {
        public override int Priority { get; } = 19;

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}