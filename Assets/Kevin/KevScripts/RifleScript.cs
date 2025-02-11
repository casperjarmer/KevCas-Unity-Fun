using UnityEngine;

public class RifleScript : MonoBehaviour
{


    public float range = 100f;
    public float fireRate = 10f;
    public Camera fpsCam;

 public ParticleSystem muzzleFlash; // Assign in Inspector
public GameObject impactEffect; // Assign in Inspector

public GameObject bloodEffect; // Assign in Inspector


private float nextTimeToFire = 0f;

 //public Animator gunAnimator; // Assign in Inspector


    // Update is called once per frame
    void Update()
    {
           if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }


    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play(); // Play muzzle flash effect
        }

        //if (gunAnimator != null)
        //{
        //    gunAnimator.SetTrigger("Recoil"); // Play recoil animation
        //}

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(10);
                if (bloodEffect != null)
                {
                    GameObject bloodGO = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(bloodGO, 2f); // Destroy effect after 2 seconds
                }
            }

            if (impactEffect != null)
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f); // Destroy effect after 2 seconds
            }
        }
    }
}
