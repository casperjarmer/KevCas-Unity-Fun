using UnityEngine;

public class BomberSc : MonoBehaviour
{

    public GameObject bomb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(-transform.up,ForceMode.Impulse);
        InvokeRepeating("SpawnBomb",1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBomb(){
        GameObject bombClone = Instantiate(bomb, transform.GetChild(0).position, Quaternion.Euler(new Vector3(0,0,90f)));
    }
}
