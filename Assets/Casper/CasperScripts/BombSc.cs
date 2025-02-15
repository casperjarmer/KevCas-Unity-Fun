using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BombSc : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        Instantiate(explosionPrefab,transform.position,quaternion.identity);
        Destroy(gameObject);
    }
}
