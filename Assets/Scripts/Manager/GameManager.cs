using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
            return;
        }
        instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void FinishGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
