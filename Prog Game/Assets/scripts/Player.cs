using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 28;

    private void Update()
    {
        // Take this out, for testing purposes only, will get rid off when enemies
        if (Input.GetKeyDown(KeyCode.E))
        {
            health -= 2;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}