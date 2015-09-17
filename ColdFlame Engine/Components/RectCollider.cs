
namespace ColdFlame
{
    public class RectCollider : Component
    {
        public float height { get; set; }
        public float width { get; set; }

        public RectCollider(float width = 0, float height = 0)
        {
            this.width = width;
            this.height = height;
        }
    }
}
