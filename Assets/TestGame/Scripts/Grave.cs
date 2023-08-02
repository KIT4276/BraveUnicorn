using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Grave : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _gravesSkins = new List<GameObject>();
    
    public void Restart()
    {
        var r = Random.Range(0, _gravesSkins.Count);
        _gravesSkins[r].SetActive(true);
    }

    public void Hide()
    {
        foreach (var item in _gravesSkins)
        {
            item.SetActive(false);
        }
    }
    
    public class Pool : MonoMemoryPool<Grave> { }
}
