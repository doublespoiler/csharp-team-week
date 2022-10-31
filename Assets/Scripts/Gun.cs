using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    [field: SerializeField]
    private float fireRate { get; set; } = 0.5f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    void Start()
    {
      StartCoroutine(ShootLogic());
      fireRate = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootLogic()
    {
      while (true)
      {
        while (Input.GetButtonDown("Fire1"))
        {
          Shoot();
          yield return new WaitForSeconds(fireRate);
        }
        yield return null;
      }
    }

    void Shoot ()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null) 
            {
                enemy.TakeDamage(damage);
            }
        }
    }

}
