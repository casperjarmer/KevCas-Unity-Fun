using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class GunSc : MonoBehaviour
{
    public Transform barrelHole;
    public GameObject bullet;
    public List<GameObject> bullets = new List<GameObject>();

    public float bulletSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bulletClone = Instantiate(bullet,barrelHole.position,quaternion.identity);
            bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed,ForceMode.Impulse);
        }
    }
}
