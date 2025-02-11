using UnityEngine;

public class SoundPulseController : MonoBehaviour
{
    public Material soundVisionMaterial;  
    public Transform player;  
    public float maxRadius = 10f;  // Maximum range of the sound pulse
    public float pulseSpeed = 5f;  // How fast the pulse expands
    private float currentRadius = 0f;  
    private bool isPulsing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Press space to trigger sound
        {
            currentRadius = 0f;  // Reset the pulse
            isPulsing = true; 
            soundVisionMaterial.SetVector("_SoundPosition", player.position);
        }

        if (isPulsing)
        {
            currentRadius += pulseSpeed * Time.deltaTime; // Expand the pulse
            soundVisionMaterial.SetFloat("_SoundRadius", currentRadius);

            if (currentRadius >= maxRadius)  
            {
                isPulsing = false;  // Stop pulse when max size is reached
            }
        }
    }
}
