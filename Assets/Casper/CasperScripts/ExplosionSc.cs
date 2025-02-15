using UnityEngine;

public class ExplosionSc : MonoBehaviour
{

    float explosionSize;
    float explosionSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explosionSize = 20;
        explosionSpeed = 75;
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(explosionSpeed,explosionSpeed,explosionSpeed) * Time.deltaTime;
        if(transform.localScale.magnitude > explosionSize)
        {
            Destroy(gameObject);
        }
    }
}
