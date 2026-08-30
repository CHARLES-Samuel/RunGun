using UnityEngine;
using UnityEngine.SceneManagement;

/**
    Permet de manipuler les scenes
*/
public class GameManager : MonoBehaviour
{   
    public static GameManager instance;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Demarre le jeu
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Respawn()
    {   
        SaveManager.instance.AddCoinsToBank(PlayerInventory.instance.currentCoins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Revenir au menu principal
    public void FinishGame()
    {   
        SaveManager.instance.AddCoinsToBank(PlayerInventory.instance.currentCoins);
        SceneManager.LoadSceneAsync(0);
    }
}
