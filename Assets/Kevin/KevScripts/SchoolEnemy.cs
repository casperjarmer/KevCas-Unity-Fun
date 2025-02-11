using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 150f;
    private Renderer enemyRenderer;


    void Start(){
        enemyRenderer = GetComponent<Renderer>();
    }



    public void TakeDamage(float amount)
    {
        health -= amount;

if (health < 0) health = 0;

        UpdateColor();

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void UpdateColor()
    {
        float healthPercentage = health / maxHealth;
        Color newColor = Color.Lerp(Color.red, Color.green, healthPercentage);
        enemyRenderer.material.color = newColor;
    }
}
