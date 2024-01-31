using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoRetry(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoRetry(float sec)
    {
        yield return new WaitForSeconds(sec);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Samples");
    }
}
