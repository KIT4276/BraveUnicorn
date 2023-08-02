using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingSystem : MonoBehaviour
{
    public event Action OnShootE;
    public event Action ShootFailE;

    private Enemy _shotEnemy;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastProcessing();
            }
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    RaycastProcessing();
        //}
    }

    private void RaycastProcessing()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider != null && hit.collider.TryGetComponent<Enemy>(out var enemy) && enemy.IsAlive)
        {
            OnShootE?.Invoke();
            _shotEnemy = enemy;
        }
        else
        {
            ShootFailE?.Invoke();
        }
    }

    public void OnShoot()
    {
        if(_shotEnemy != null &&  _shotEnemy.IsAlive)
            _shotEnemy.EnemiesDeath();
    }
}
