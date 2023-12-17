using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStatus
    {
        WaitingCountdown,
        Running,
        Paused,
        End
    }
    public gameStatus status;

    private void Awake()
    {
        status = gameStatus.WaitingCountdown;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator countdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        status = gameStatus.Running;
    }
}
