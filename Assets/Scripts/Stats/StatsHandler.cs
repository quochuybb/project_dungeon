using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;

public class StatsHandler : MonoBehaviour
{

    [SerializeField] public CharacterStats stats;
    private CharacterController characterController;
    [SerializeField] public ChangeHealthBar healthBar;
    [SerializeField] public Bullet bullet;
    [SerializeField] public Melee melee;
    [SerializeField] public List<GameObject> bottle;
    [SerializeField] public GameObject gameOver;
    public CharacterStats CurrentHealth { get; private set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        CurrentHealth = stats.Clone();
        characterController.onDamgeEvent.AddListener(ChangedHealth);
        characterController.onDeathEvent.AddListener(Death);
    }

    public void ChangedHealth(float damage)
    {
        CurrentHealth.maxHealth -= damage;
        if (CurrentHealth.maxHealth <= 0)
        {
            characterController.isDead = true;
        }
    }

    public void ChangedDamage(float damage)
    {
        bullet.damage += damage;
        melee.damage += damage;

    }

    public void ChangedNumberBullet(int amount)
    {
        bullet.numberOfBulletsPerShoot += amount + 1;
    }

    public void Death()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("test");
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            Instantiate(bottle[randomNumber], transform.position, Quaternion.identity).SetActive(true);
            Debug.Log(bottle[randomNumber].name);
            gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            ItemObject itemObject = other.gameObject.GetComponent<ItemObject>();
            if (itemObject.item.actionType == ActionType.health)
            {
                ChangedHealth(itemObject.item.buff);
            } else if (itemObject.item.actionType == ActionType.attack)
            {
                ChangedDamage(itemObject.item.buff);
            }
            else
            {
                ChangedNumberBullet((int)itemObject.item.buff);
            }
            itemObject.gameObject.SetActive(false);
        }
    }

}
