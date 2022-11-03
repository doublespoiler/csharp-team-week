using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterStats
{
    AudioSource player_AudioSource;

    public HealthBar healthBar;
    public Player stats;
    
    void Start()
    {
      player_AudioSource = GetComponent<AudioSource>();
      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
    }

    private void Update() 
    { 
      if(currentHealth <= 0)
      {
        Debug.Log("player health 0");
        Die();
      }
      if(Input.GetKeyDown(KeyCode.E))
      {
        HealthRefresh();
      }
    }

    public void HealthRefresh()
    {
      healthBar.SetHealth(currentHealth);
      if(currentHealth <= 0)
      {
        Debug.Log("player health 0");
        Die();
      }
    }

    public void TakeDamage(GameObject source, int damage)
    {
      if(source.tag == "enemy")
      {
        player_AudioSource.Play();
        currentHealth -= damage;
        HealthRefresh();
        Debug.Log(name + " took damage from " + source.name + " for " + damage + " damage!");
      }
    }
    
}
