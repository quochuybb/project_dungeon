using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public bool useGun;
    public bool useMelee;
    public bool isDead = false;
    public bool canThrow = false;
    private float lastTimeShoot;
    protected float lastTimeAttack = 0;
    [SerializeField] protected Bullet bulletConfig;
    [SerializeField] protected Melee meleeConfig;
    [SerializeField] protected BombConfig bombConfig;

    public virtual void Awake()
    {
        useGun = false;
        useMelee = false;
    }

    public virtual void Update()
    {
        HandleDelayTime();
        if (isDead)
        {
            onDeathEvent.Invoke();
        }
    }

    public void HandleDelayTime()
    {
        lastTimeShoot += Time.deltaTime;
        if (useGun && lastTimeShoot > bulletConfig.delay)
        {
            lastTimeShoot = 0f;
            useGun = false;
            onAttackGunEvent.Invoke(bulletConfig);
        }

        if (useMelee && !useGun)
        {
            useMelee = false;
            onAttackMeleeEvent.Invoke(meleeConfig);
        }

        if (canThrow)
        {
            canThrow = false;
            onThrow.Invoke();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {   
            BulletController bulletController = other.gameObject.GetComponent<BulletController>();
            if (bulletController != null && !isDead)
            {
                onDamgeEvent.Invoke(bulletController.GetDamage());
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            Debug.Log(other.gameObject.name);
            onDamgeEvent.Invoke(bombConfig.damage);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Melee"))
        {
            onDamgeEvent.Invoke(meleeConfig.damage);
        }
    }

    private readonly MoveEvent _moveEvent = new MoveEvent();
    private readonly LookEvent _lookEvent = new LookEvent();
    private readonly AttackMeleeEvent _attackMelee = new AttackMeleeEvent();
    private readonly AttackGunEvent _attackGun = new AttackGunEvent();
    private readonly ThrowEvent _throwEvent = new ThrowEvent();
    private UnityEvent OnDeath = new UnityEvent();
    private UnityEvent OnHealthChanged = new UnityEvent();
    private UnityEvent<float> OnDamge  = new UnityEvent<float>();
    private UnityEvent _onDash = new UnityEvent();

    public ThrowEvent onThrow => _throwEvent;
    public UnityEvent onDash => _onDash;
    public AttackMeleeEvent onAttackMeleeEvent => _attackMelee;
    public AttackGunEvent onAttackGunEvent => _attackGun;
    public MoveEvent onMoveEvent => _moveEvent;
    public LookEvent onLookEvent => _lookEvent;
    public UnityEvent onDeathEvent => OnDeath;
    public UnityEvent onHealthChangedEvent => OnHealthChanged;
    public UnityEvent<float> onDamgeEvent => OnDamge;
}
