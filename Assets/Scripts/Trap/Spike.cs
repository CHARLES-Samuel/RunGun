using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int spikeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            Debug.Log("degat de spike");
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeSpikeDamage(spikeDamage);
            }
        }
    }
}
