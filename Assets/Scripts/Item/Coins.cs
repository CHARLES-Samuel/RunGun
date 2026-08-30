using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int valueOfCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInventory.instance.ModifyCoins(valueOfCoin);
            Destroy(gameObject);
        }
    }
}
