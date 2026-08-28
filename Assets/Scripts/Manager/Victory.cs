using UnityEngine;

/**
    Condition de victoire
*/
public class Victory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.FinishGame();
        }
    }
}
