using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    public int currentCoins;
    public event Action OnCoinsChanged;

    public static PlayerInventory instance;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerInventory dans la scène");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void ModifyCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;

        if (currentCoins < 0)
        {
            currentCoins = 0;
        }
        
        OnCoinsChanged?.Invoke();
    }
}
