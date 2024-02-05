using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject HUDObject;
    public GameObject DialogueObject;



    private string tutorialText = "Hey there!\nYou are trapped here too, I see.\nWell, since we are at it, why don't we bail together?\nYou could use a guide around here.\nUse WASD to move. Enter to attack and Space to perform a dash.\nI see you lost your arm!\nSwinging your sword will reduce your health, that's too bad...\nBut we are in luck! \nSee that enemy with the halo over their head?\nDefeat them to get your energy back!\nGood luck!";
    private string[] tutorialTexts;
    private int currentindex;

    private bool fightEnd;

    private void Awake()
    {
        status = gameStatus.WaitingCountdown;
    }
    // Start is called before the first frame update
    void Start()
    {
        tutorialTexts = tutorialText.Split('\n');
        if (GameObject.Find("ValueHolder").GetComponent<ValueHolder>().isFirstTime)
        {
            GameObject.Find("ValueHolder").GetComponent<ValueHolder>().isFirstTime = false;
            HUDObject.SetActive(false);
            DialogueObject.SetActive(true);
            currentindex = 0;
            UpdateDialogueText();
        }
        else
        {
            StartCoroutine(countdown(0));
            HUDObject.SetActive(true);
            DialogueObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !fightEnd)
        {
            Destroy(GameObject.FindGameObjectWithTag("Exit").transform.GetChild(1).gameObject);
            fightEnd = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentindex == tutorialTexts.Length - 1)
            {
                DialogueObject.SetActive(false);
                HUDObject.SetActive(true);
                StartCoroutine(countdown(0));
            }
            else if (currentindex >= tutorialTexts.Length)
            {

            }
            else
            {
                currentindex++;
                UpdateDialogueText();
            }
        }
    }

    private void UpdateDialogueText()
    {
        DialogueObject.GetComponentInChildren<Text>().text = tutorialTexts[currentindex];
    }

    private IEnumerator countdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        status = gameStatus.Running;
    }
}
