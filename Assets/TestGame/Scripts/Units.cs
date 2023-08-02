using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField]
    protected float _moveSpeed = 0.05f;
    [SerializeField]
    protected float _delay = 3;

    [Space, SerializeField]
    protected GameObject _skeletonObj;
    [SerializeField]
    protected GameObject _grave;

    [Space, SerializeField]
    protected SkeletonAnimation _skeletonAnimation;
    [SerializeField, SpineAnimation]
    protected string _deathAnimation;
    [SerializeField, SpineAnimation]
    protected string _walkAnimation;

    public bool IsAlive { get; protected set; }
    public bool IsAnimated { get; protected set; }

    protected virtual void Start()
    {
        IsAlive = true;
    }

    protected void FixedUpdate()
    {
       if(IsAlive && !IsAnimated) transform.position += new Vector3(_moveSpeed, 0f);

        _skeletonAnimation.AfterAnimationApplied();
    }

    protected void Death()
    {
        SetAnimation(_deathAnimation, false);
        IsAlive = false;
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSecondsRealtime(_delay);

        AfterDeath();
    }

    protected virtual void AfterDeath() { }

    protected void SetAnimation(string name, bool loop)
    {
        _skeletonAnimation.state.SetAnimation(0, name, loop);
    }
}
