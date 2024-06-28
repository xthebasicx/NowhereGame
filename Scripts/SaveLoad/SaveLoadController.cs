using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadController : MonoBehaviour
{
    public PlayerHealth playerData;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadGame();
        }
    }
    public void SaveGame()
    {
        SaveSystem.SaveGame(playerData);
    }
    public void LoadGame()
    {
        SaveData saveData = SaveSystem.LoadGame();
        playerData.transform.position = saveData.playerPosition;
        SceneManager.LoadScene(saveData.sceneName);
        playerData.SetHealth(saveData.CurrentHP);
    }
}