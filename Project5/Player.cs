using Microsoft.Xna.Framework;

namespace Project5
{
    internal class Player
    {
        public Rectangle Collider;
        public Rectangle floorDetector;
        int w = 20;
        int h = 20;
        int lastChange;

        float mass = 1f;
        float velocity = 0f;

        bool onFloor = false;

        public Player(int x, int y)
        {
            Collider = new Rectangle(x, y, w, h);
            floorDetector = Collider;
            floorDetector.Y += h / 2;
        }
        void UpdateFloorDetector()
        {
            floorDetector = Collider;
            floorDetector.Y += h / 2;
        }
        public void Update(bool onFloor, Rectangle floor)
        {
            this.onFloor = onFloor;

            if (!this.onFloor)
            {
                velocity -= mass * Globals.Gravity;
                Collider.Y += (int)(velocity * Globals.dt);
            }
            else
            {
                Collider.Y = floor.Top - h;
                velocity = 0f;
            }

            if (onFloor) { }
            UpdateFloorDetector();
        }
        public void Draw()
        {
            Globals.sb.Draw(Globals.pixel, Collider, Color.White);
        }
    }
}
