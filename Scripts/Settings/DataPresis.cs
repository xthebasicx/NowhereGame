using UnityEngine;

public class DataPresis : MonoBehaviour
{
    private static GameObject[] PresisData = new GameObject[3];
    public int objectIndex;


    void Awake()
    {
        if (PresisData[objectIndex] == null)
        {
            PresisData[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (PresisData[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }

    }
    public static void DestroyAllPresisData()
    {
        for (int i = 0; i < PresisData.Length; i++)
        {
            if (PresisData[i] != null)
            {
                Destroy(PresisData[i]);
                PresisData[i] = null;
            }
        }
    }
}
