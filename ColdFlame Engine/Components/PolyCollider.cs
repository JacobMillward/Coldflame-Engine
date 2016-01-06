using System.Collections.Generic;

namespace ColdFlame.Components
{
    public class PolyCollider : Component
    {
        private List<float> Points { get; }

        public PolyCollider(List<float> points)
        {
            this.Points = points;
        }
    }
}