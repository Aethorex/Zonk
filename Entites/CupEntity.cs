using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zonk.EC;

namespace Zonk.Entites
{
    internal class CupEntity : AEntity
    {
        private Texture2D cupSprite = null!;
        float rotation = 0;
        float dir = 1;

        public override void Init()
        {
            cupSprite = Zonk.Instance.Content.Load<Texture2D>("cup");
        }

        public override void Update(GameTime gameTime)
        {
            rotation += 1f * (float)gameTime.ElapsedGameTime.TotalSeconds * dir;
            if (rotation > 0.2 || rotation < 0)
            {
                dir *= -1;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cupSprite,
                new Vector2(100, 100),
                null,
                Color.White,
                rotation,
                new Vector2(cupSprite.Width / 2, cupSprite.Height - 20),
                1f,
                SpriteEffects.None,
                0.5f
            );
        }
    }
}
