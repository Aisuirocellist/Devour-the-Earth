using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int startingHealth = 5;
    private int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
