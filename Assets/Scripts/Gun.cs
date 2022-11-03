using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  Animator gun_Animator;
  AudioSource gun_AudioSource;

  private AudioSource[] clips;

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

  [field: SerializeField]
  private UIManager _uiManager;

  void Start()
  {
    gun_Animator = gameObject.GetComponent<Animator>();
    clips = gameObject.GetComponents<AudioSource>();
    _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    CDTimer = coolDown;
    ammo = maxAmmo;
    _uiManager.UpdateAmmoDisplay(ammo, maxAmmo);
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
      Shoot();  //ISSUE
    }

    if(Input.GetKeyDown(KeyCode.R))
    {
      StartCoroutine(Reload());
      return;
    }
  }

  void Shoot ()
  {
    muzzleFlash.Play();
    clips[Random.Range(0, clips.Length)].Play();
    ammo--;
    RaycastHit hit;
    _uiManager.UpdateAmmoDisplay(ammo, maxAmmo);  //Updates ammo count after Gun is fired. 
    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
    {
      Debug.Log(hit.transform.name);
      GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
      Destroy(impactGO, 2f);  //To GameObject: "Destroy yourself after you've existed for 2 seconds (about same length as hit impact animation)"
      if (hit.rigidbody != null)
      {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }

      TEST enemy = hit.transform.GetComponent<TEST>();
      
      if (enemy != null) 
      {
        enemy.TakeDamage(damage);  //ISSUE
      }
    }
  }

  IEnumerator Reload()
  {
    isReloading = true;
    gun_Animator.SetTrigger("Reload");
    Debug.Log("reloading...");
    yield return new WaitForSeconds(reloadTime);
    Debug.Log("reload done! Pew pew!");
    ammo = maxAmmo;
    _uiManager.UpdateAmmoDisplay(ammo, maxAmmo);
    isReloading = false;
  }

}
