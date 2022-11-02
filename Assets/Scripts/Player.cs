using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    
    void Start()
    {
      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      if(currentHealth <= 0)
      {
        Die();
      }
    }

    public void TakeDamage(GameObject source, int damage)
    {
      if(source.tag == "enemy")
      {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(name + " took damage from " + source.name + " for " + damage + " damage!");
      }
    }

    void Die()
    {
      Debug.Log("player has died!");
    }
}
