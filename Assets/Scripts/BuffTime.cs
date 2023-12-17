using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffTime : MonoBehaviour
{
    public Image filled_image;
    [SerializeField] float buff_time;
    float counter;
    float display;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        filled_image.fillAmount += 1.0f / buff_time * Time.deltaTime;

    }

    IEnumerator BuffImagaeFiller(Image filled_image, float duration)
    {
        float time = 0;
        

        while (time < duration)
        {
            time += 1 * Time.deltaTime;
            Debug.Log(time + " " + duration);


            filled_image.fillAmount = Mathf.Lerp(0, duration, time);
        }
        yield return null;
    }
}
