using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    EnemyController ec;
    List<GameObject> bonus;
    

    private void Start()
    {
        ec = transform.GetComponentInParent<EnemyController>();
        bonus = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.CompareTag("Bonus"))
        {
            ec.busy = true;
            ec.setCurrentEnemyState(EnemyController.EnemyStates.Bonus);
            ec.bonus = other.gameObject;
        }

        if (other.CompareTag("Player") && !ec.busy)
        {
            ec.setCurrentEnemyState(EnemyController.EnemyStates.Chasing);
        }


    }
}
