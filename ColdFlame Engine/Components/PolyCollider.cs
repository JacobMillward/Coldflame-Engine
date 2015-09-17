
using System.Collections.Generic;

namespace ColdFlame
{
    public class PolyCollider : Component
    {
        public List<float> points;

        public PolyCollider(List<float> points)
        {
            this.points = points;
        }
    }
}
