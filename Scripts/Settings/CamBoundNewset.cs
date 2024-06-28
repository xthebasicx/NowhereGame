using UnityEngine;
using UnityEngine.SceneManagement;

public class CamBoundNewset : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Game":
                transform.position = new Vector2(0, 0);
                break;

            case "Room1":
                transform.position = new Vector2(82, 0);
                break;

            case "Room2":
                transform.position = new Vector2(82, -53);
                break;


        }
    }
}
