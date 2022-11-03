using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

  public Player stats;
  public HealthBar healthBar;

  [SerializeField] private float pickupRange;
  [SerializeField] private LayerMask pickupLayer;

  private Camera cam;

    private void Start() 
    {
      GetReferences();
    }
  
    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.E))
      {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
        {
          Debug.Log("Hit: " + hit.transform.name);

          if(hit.transform.GetComponent<ItemObject>().item)
          {
            Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
              stats.Heal(stats.GetMaxHealth());
              Debug.Log("HEALING " + stats.GetCurrentHealth());
          }
        }
        Destroy(hit.transform.gameObject);
      }
    }
    private void GetReferences() 
    {
      cam = GetComponentInChildren<Camera>();
      stats = GetComponent<Player>();
    }
}