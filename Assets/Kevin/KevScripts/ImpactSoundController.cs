using UnityEngine;

public class ImpactSoundController : MonoBehaviour
{
    // Pulse variables
    public float pulseExpansionSpeed = 5f;  // How fast the pulse expands (you can adjust this)
    private float currentImpactRadius = 0f; // Current pulse radius
    private float maxImpactRadius = 10f;  // Max radius before pulse fades away
    private bool isPulseActive = false;   // Whether the pulse is active
    private Vector3 pulseOrigin;          // The position where the pulse originates from

    void Start()
    {
        currentImpactRadius = 0f; // Initialize the pulse radius to 0
    }

    void Update()
    {
        // If the pulse is active, expand it over time
        if (isPulseActive)
        {
            currentImpactRadius += pulseExpansionSpeed * Time.deltaTime; // Expand radius
            currentImpactRadius = Mathf.Min(currentImpactRadius, maxImpactRadius); // Limit max size
            
            // Log pulse radius expansion for debugging
            Debug.Log("Pulse Expanding: " + currentImpactRadius);

            // Send the pulse radius to all the quads
            ApplyPulseToQuads();

            // Reset the pulse if it reaches the max size
            if (currentImpactRadius >= maxImpactRadius)
            {
                isPulseActive = false; // Stop the pulse after max size
            }
        }
    }

    // When the collision happens, start the pulse expansion
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Quad")) // Assuming your quads are tagged "Quad"
        {
            Debug.Log("Cube collided with: " + collision.gameObject.name);

            // Get the cube's position when the collision happens
            pulseOrigin = collision.transform.position;

            // Start expanding the pulse when collision happens
            currentImpactRadius = 1f; // Initial size of the pulse
            isPulseActive = true;     // Activate the pulse

            // Optionally, apply the impact radius to the colliding object immediately
            Material quadMaterial = collision.gameObject.GetComponent<Renderer>().material;
            quadMaterial.SetFloat("_ImpactRadius", currentImpactRadius);
        }
    }

    // Function to apply the pulse radius to all relevant quads in the scene
    void ApplyPulseToQuads()
    {
        // Find all the quads and apply the pulse radius
        GameObject[] quads = GameObject.FindGameObjectsWithTag("Quad");  // Assuming quads are tagged as "Quad"

        foreach (GameObject quad in quads)
        {
            // Get the distance from the pulse origin to the quad's position
            float distanceToQuad = Vector3.Distance(pulseOrigin, quad.transform.position);
            
            // Apply the pulse effect based on the distance
            Material quadMaterial = quad.GetComponent<Renderer>().material;
            quadMaterial.SetFloat("_ImpactRadius", currentImpactRadius);
            quadMaterial.SetFloat("_DistanceToPulse", distanceToQuad); // New property that can be used to modulate effect
        }
    }
}
