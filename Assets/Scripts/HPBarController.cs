using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public GameObject HPFill;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        updateHPBar();

        if (Input.GetKey(KeyCode.P)) player.HP_Now--;
    }

    private void updateHPBar()
    {
        float HP_Ratio = player.HP_Now / player.HP_Max;
        HPFill.transform.localScale = new Vector3(HP_Ratio, 1f, 1f);
        Color HPFill_color = new Color();
        if (HP_Ratio >= 0.5f) HPFill_color = new Color(1 - (HP_Ratio - 0.5f) * 2, 1f, 0f);
        else HPFill_color = new Color(1f, HP_Ratio * 2, 0f);
        HPFill.GetComponent<Image>().color = HPFill_color;
    }
}
