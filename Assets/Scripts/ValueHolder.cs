using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    public bool isFirstTime = true;
    public int currentRoom = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ToGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Samples");
    }
}
