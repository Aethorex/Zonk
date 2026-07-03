using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zonk.EC;

namespace Zonk.Scenes;

public class DebugScene : AScene
{
    public override void Init()
    {
        base.Init();
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Zonk.Instance.Exit();
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            Zonk.Instance.SetNextScene(new GameScene());
        }

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
