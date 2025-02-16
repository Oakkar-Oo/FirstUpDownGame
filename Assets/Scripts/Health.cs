using System.Diagnostics.Contracts;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;


    void Start()
    {
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentException("Cannot have negative damage");
        }

        this.health -= amount;

        if (health < 0)
        {
            Die();
        }
    }
    
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentException("Cannot have negative damage");
        }


        bool OverMaxHealth = health + amount > MAX_HEALTH;

        if (OverMaxHealth)
        {
            health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}
