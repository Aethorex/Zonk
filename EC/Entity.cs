using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zonk.EC;

public class Entity
{
    public virtual void Init() { }

    public virtual void Update(GameTime gameTime) { }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

    public virtual void Destroy() { }
}