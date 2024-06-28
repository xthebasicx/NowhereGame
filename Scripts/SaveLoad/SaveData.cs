using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public float CurrentHP;
    public string sceneName;
    public Vector3 playerPosition;
    public SaveData(PlayerHealth playerData)
    {
        this.CurrentHP = playerData.CurrentHP;
        this.playerPosition = playerData.transform.position;
        this.sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(this.sceneName + " " + this.playerPosition + " " + this.CurrentHP);
    }
}