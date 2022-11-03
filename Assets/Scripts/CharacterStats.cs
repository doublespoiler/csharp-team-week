using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
  [SerializeField] protected int currentHealth;
  [SerializeField] protected int maxHealth;

  [SerializeField] protected bool isDead;
  [SerializeField]UIManager _uiManager;


  private void Start()
    {
      InitVariables();
      _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      if(_uiManager == null)
      {
        Debug.Log("CANVAS NULL");
      }else
      {
        Debug.Log("CANVAS GET");
      }
    }

  public void CheckHealth()
    {
      Debug.Log("current health" + currentHealth);
      if (currentHealth <= 0)
      {
        currentHealth = 0;
        Die();
      }

      if(currentHealth >= maxHealth)
      {
        currentHealth = maxHealth;
      }
    }

  public void Die()
    {
      Debug.Log("Player is dead!");
      isDead = true;
      _uiManager.GameOver();
    }
  
  private void SetHealthTo(int healthToSetTo)
    {
      currentHealth = healthToSetTo;
      CheckHealth();
    }
  
  public void TakeDamage(int damage)
    {
      int healthAfterDamage = currentHealth - damage;
      SetHealthTo(healthAfterDamage);
    }
  
  public void Heal(int heal)
    {
      int healthAfterHeal = currentHealth + heal;
      SetHealthTo(healthAfterHeal);
    }

  public int GetMaxHealth()
    {
      return maxHealth;
    }
  
  public int GetCurrentHealth()
    {
      return currentHealth;
    }
  public void InitVariables()
    {
      maxHealth = 100;
      SetHealthTo(maxHealth);
      isDead = false;
    }
}
