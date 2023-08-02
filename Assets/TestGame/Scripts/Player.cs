using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : Units
{
    [SerializeField, SpineAnimation]
    protected string _shootAnimation;
    [SerializeField, SpineAnimation]
    protected string _looseShootAnimation;
    [SerializeField, SpineAnimation]
    protected string _idleAnimation;
    
    [SerializeField]
    private ParticleSystem _electroShoot;

    [Space, SerializeField]
    private AudioClip _shootAudio;
    [SerializeField]
    private AudioClip _looseShootAudio;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioLose;

    [Inject]
    private ShootingSystem _shootingSystem;

    protected override void Start()
    {
        base.Start();
        _shootingSystem.OnShootE += OnShoot;
        _shootingSystem.ShootFailE += ShootFail;
        _skeletonAnimation.state.Event += PlayerShoot;
    }

    private void EndAnimation(TrackEntry trackEntry)
    {
        SetAnimation(_walkAnimation, true);
        IsAnimated = false;
        trackEntry.Complete -= EndAnimation;
    }

    private void PlayerShoot(TrackEntry trackEntry, Spine.Event e)
    {
        if (trackEntry.Animation.Name != _looseShootAnimation)
            _shootingSystem.OnShoot();

        IsAnimated = true;
        trackEntry.Complete += EndAnimation;
    }

    private void ShootFail()
    {
        SetAnimation(_looseShootAnimation, false);
        _audioSource.clip = _looseShootAudio;
        _audioSource.Play();
    }

    private void OnShoot()
    {
        SetAnimation(_shootAnimation, false);
        _electroShoot.Play();
        _audioSource.clip = _shootAudio;
        _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy) && enemy.IsAlive)
        {
            _audioSource.clip = _audioLose;
            _audioSource.Play();
            Death();
        }

        if(collision.TryGetComponent < WinTrigger>(out var win))
        {
            IsAlive = false;
            SetAnimation(_idleAnimation, true);
            win.Win();
        }
    }

    private void OnDestroy()
    {
        _shootingSystem.OnShootE -= OnShoot;
        _shootingSystem.ShootFailE -= ShootFail;
        _skeletonAnimation.state.Event -= PlayerShoot;
    }

    protected override void AfterDeath()
    {
        _skeletonObj.SetActive(false);
        _grave.SetActive(true);
    }
}
