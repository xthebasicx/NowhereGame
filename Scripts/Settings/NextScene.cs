using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private String sceneName;
    public int x;
    public int y;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == player)
        {
            switch (LoadScene(sceneName))
            {
                case "Game":
                    player.transform.position = new Vector2(x, y);
                    break;

                case "Room1":
                    player.transform.position = new Vector2(x, y);
                    break;

                case "Room2":
                    player.transform.position = new Vector2(x, y);
                    break;

            }
        }
    }
    private string LoadScene(String sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        return sceneName;
    }
}
