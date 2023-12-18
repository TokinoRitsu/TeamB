using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    GameObject player_object;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_object == null)
        {
            player_object = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            gameObject.transform.position = new Vector3(player_object.transform.position.x + 3f, transform.position.y, player_object.transform.position.z - 3);
        }
    }
}
