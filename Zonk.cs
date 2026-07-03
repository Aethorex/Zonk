using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zonk.EC;
using Zonk.Scenes;

namespace Zonk;

public class Zonk : Game
{
    public static Zonk Instance { get; } = new();

    public AScene CurrentScene { get; private set; } = null!;

    private AScene? NextScene = null;
    private SpriteBatch _spriteBatch = null!;
    private readonly GraphicsDeviceManager _graphics;

    public Zonk()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            SynchronizeWithVerticalRetrace = false, // VSync
            GraphicsProfile = GraphicsProfile.HiDef,
            PreferredBackBufferWidth = 960,
            PreferredBackBufferHeight = 720,
            IsFullScreen = false,
        };
        IsMouseVisible = true;
        InactiveSleepTime = TimeSpan.Zero;
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SetNextScene(new DebugScene());
    }

    protected override void Update(GameTime gameTime)
    {
        if (NextScene is not null)
        {
            CurrentScene?.Dispose();
            CurrentScene = NextScene;
            NextScene = null;
            CurrentScene.Init();
        }

        CurrentScene.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);
        CurrentScene.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
    }

    public void SetNextScene(AScene nextScene)
    {
        NextScene = nextScene;
    }

    protected override void OnExiting(object _1, ExitingEventArgs _2)
    {
        CurrentScene?.Dispose();
    }
}
