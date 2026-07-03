using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Zonk.EC;

public abstract class AScene
{
    public IReadOnlyList<Entity> Entities => Entities;

    private readonly List<Entity> _entities = [];

    public virtual void Init()
    {
        foreach (Entity entity in _entities)
            entity.Init();
    }

    public virtual void Update(GameTime gameTime)
    {
        foreach (Entity entity in _entities)
            entity.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (Entity entity in _entities)
            entity.Draw(gameTime, spriteBatch);
    }

    public virtual void Dispose()
    {
        foreach (Entity entity in _entities)
            entity.Destroy();
    }

    public void AttachEntity(Entity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        _entities.Remove(entity);
    }

    public T? GetEntity<T>() where T : Entity
        => _entities.OfType<T>().FirstOrDefault();

    public IEnumerable<T> GetEntities<T>() where T : Entity
        => _entities.OfType<T>();
}
