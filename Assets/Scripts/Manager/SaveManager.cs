using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();
    public static SaveManager instance;

    private string filePath;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de SaveManager dans la scène");
            Destroy(gameObject);
            return;
        }
        instance = this;

        filePath = Application.persistentDataPath + "/PlayerData.json";
        LoadFromJson();
    }

    public void SaveToJson()
    {   
        playerData.coins = PlayerInventory.instance.currentCoins;

        string data = JsonUtility.ToJson(playerData);
        Debug.Log(filePath);
        File.WriteAllText(filePath, data);
        Debug.Log("Sauvegarde effectuee");
    }

    public void LoadFromJson()
    {   
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(data);
            PlayerInventory.instance.currentCoins = playerData.coins;
            Debug.Log("Chargement effectue");
        }
        else
        {
            Debug.Log("Aucune sauvegarde trouve");
            playerData = new PlayerData();
        }
    }
}
