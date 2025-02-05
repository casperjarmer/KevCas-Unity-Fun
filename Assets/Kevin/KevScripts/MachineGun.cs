using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public float range = 100f;
    public float fireRate = 10f;
    public Camera fpsCam;

    public ParticleSystem muzzleFlash; // Assign in Inspector
    public GameObject impactEffect; // Assign in Inspector

    private float nextTimeToFire = 0f;

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

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(50);
            }

            if (impactEffect != null)
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f); // Destroy effect after 2 seconds
            }
        }
    }
}
