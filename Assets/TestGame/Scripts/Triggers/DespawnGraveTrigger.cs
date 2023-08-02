using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DespawnGraveTrigger : MonoBehaviour
{
    [SerializeField]
    private Grave _grave;
    
    [Inject]
    private GraveFactory _graveFactory;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _graveFactory.DespawnGrave(_grave);
    }
}
