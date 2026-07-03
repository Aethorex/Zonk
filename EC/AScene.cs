using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Zonk.EC;

public abstract class AScene
{
    public IReadOnlyList<AEntity> Entities => Entities;

    private readonly List<AEntity> _entities = [];

    public virtual void Init()
    {
        foreach (AEntity entity in _entities)
            entity.Init();
    }

    public virtual void Update(GameTime gameTime)
    {
        foreach (AEntity entity in _entities)
            entity.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (AEntity entity in _entities)
            entity.Draw(gameTime, spriteBatch);
    }

    public virtual void Dispose()
    {
        foreach (AEntity entity in _entities)
            entity.Destroy();
    }

    public void AttachEntity(AEntity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveEntity(AEntity entity)
    {
        _entities.Remove(entity);
    }

    public T? GetEntity<T>() where T : AEntity
        => _entities.OfType<T>().FirstOrDefault();

    public IEnumerable<T> GetEntities<T>() where T : AEntity
        => _entities.OfType<T>();
}
