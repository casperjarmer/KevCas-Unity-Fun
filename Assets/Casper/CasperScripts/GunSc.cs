using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameObject bulletClone = Instantiate(bullet,barrelHole.position,Quaternion.identity);
            bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed,ForceMode.Impulse);
        }

        LookAtMouse();



    }
    void LookAtMouse(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)){
            transform.LookAt(hit.point);
        }
        
    }
}
