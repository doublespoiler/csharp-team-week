using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int health { get; set; }
    // Start is called before the first frame update
    
    void Start()
    {
      health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(GameObject source, int damage)
    {
      if(source.tag == "enemy")
      {
        health -= damage;
        Debug.Log(name + " took damage from " + source.name + " for " + damage + " damage!");
      }
    }
}
