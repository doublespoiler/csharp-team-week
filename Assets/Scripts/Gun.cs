using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    [field: SerializeField]
    private float coolDown = 1f;
    float CDTimer;
    [field: SerializeField]
    private int maxAmmo = 10;
    [field: SerializeField]
    private float reloadTime;
    private int ammo;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    void Start()
    {
      CDTimer = coolDown;
      ammo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
      if(isReloading)
      {
        return;
      }

      if(ammo == 0)
      {
        StartCoroutine(Reload());
        return;
      }

      if(CDTimer < coolDown)
      {
        CDTimer += Time.deltaTime;
      }
      if (Input.GetButton("Fire1") && CDTimer >= coolDown && ammo > 0)
      {
        CDTimer = 0;
        Shoot();
      }

      if(Input.GetButton("Reload"))
      {
        StartCoroutine(Reload());
        return;
      }
    }

  void Shoot ()
  {
  muzzleFlash.Play();
  ammo--;
  RaycastHit hit;
  if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
  {
      Debug.Log(hit.transform.name);

      EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
      if (enemy != null) 
      {
          enemy.TakeDamage(damage);
      }

      if (hit.rigidbody != null)
      {
          hit.rigidbody.AddForce(-hit.normal * impactForce);
      }

      GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
      Destroy(impactGO, 2f);
    }
  }

  IEnumerator Reload()
  {
    isReloading = true;
    Debug.Log("reloading...");
    yield return new WaitForSeconds(reloadTime);
    Debug.Log("reload done! Pew pew!");
    ammo = maxAmmo;
    isReloading = false;
  }

}
