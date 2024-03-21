using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project5
{
    internal class Globals
    {
        public static SpriteBatch sb;
        public static Texture2D pixel;
        public static void SET_DT(GameTime gt)
        {
            dt = (float)gt.ElapsedGameTime.TotalSeconds;
        }
        public static float dt;

        public static float Gravity = -9.81f;
    }
}
