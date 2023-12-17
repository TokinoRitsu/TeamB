using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().busy = false;
            if (other.gameObject.GetComponent<EnemyController>().chasingTarget)
            {
                other.gameObject.GetComponent<EnemyController>().setCurrentEnemyState(EnemyController.EnemyStates.Chasing);
            } else
            {
                other.gameObject.GetComponent<EnemyController>().setCurrentEnemyState(EnemyController.EnemyStates.Idle);
            }
            
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        
    }
}
