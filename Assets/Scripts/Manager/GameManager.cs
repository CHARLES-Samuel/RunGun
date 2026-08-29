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
        SceneManager.LoadSceneAsync(1);
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Revenir au menu principal
    public void FinishGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
