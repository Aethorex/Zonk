using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zonk.EC;
using Zonk.Entites;

namespace Zonk.Scenes;

internal class GameScene : AScene
{
    public override void Init()
    {
        CupEntity cup = new();
        AttachEntity(cup);

        base.Init();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Zonk.Instance.GraphicsDevice.Clear(Color.Gray);

        base.Draw(gameTime, spriteBatch);
    }
}
