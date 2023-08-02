using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GraveFactory 
{
    [Inject]
    private Grave.Pool _gravesPool;

    private readonly List<Grave> _graves = new List<Grave>();

    public Grave SpawnGrave(Vector2 pos)
    {
        var grave = _gravesPool.Spawn();

        _graves.Add(grave);
        grave.transform.localPosition = new Vector2(pos.x, grave.transform.localPosition.y);
        grave.Restart();
        return grave;
    }

    public void DespawnGrave(Grave grave)
    {
        grave.Hide();
        _gravesPool.Despawn(grave);
        _graves.Remove(grave);
    }
}
