using UnityEngine;
using UnityEngine.SceneManagement;

/**
    Permet de manipuler les scenes
*/
public class GameManager : MonoBehaviour
{   
    public static GameManager instance;

    [SerializeField] private GameObject weaponMenu;

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

    // Revenir au menu principal
    public void FinishGame()
    {   
        SaveManager.instance.AddCoinsToBank(PlayerInventory.instance.currentCoins);
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenWeaponMenu()
    {
        weaponMenu.SetActive(true);
    }

    public void CloseWeaponMenu()
    {
        weaponMenu.SetActive(false);
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }
}
