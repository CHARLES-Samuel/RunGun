using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{   
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private PlayerHealth playerHealth;

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void Respawn()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerHealth.Respawn();
        gameOverUI.SetActive(false);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
