using Microsoft.Xna.Framework;

namespace Project5
{
    internal class CollisionDetector
    {
        Rectangle r1;
        Rectangle r2;
        public CollisionDetector(Rectangle r1, Rectangle r2)
        {
            this.r1 = r1;
            this.r2 = r2;
        }
        public void Update(Rectangle r1, Rectangle r2)
        {
            this.r1 = r1;
            this.r2 = r2;
        }
        public bool Collision()
        {
            return r1.Intersects(r2);
        }
    }
}
