using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnhitTrigger : MonoBehaviour
{
    EnemyController ec;
    

    private void Start()
    {
        ec = transform.GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ec.hit && ec.getCurrentEnemyState() == EnemyController.EnemyStates.Attack)
        {
            Damaged(ec.GetEnemy().GetAttack(), other.gameObject);
            ec.hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    void Damaged(float amount, GameObject hit)
    {
        hit.GetComponent<PlayerController>().HP_Now -= amount;
    }

    void OnAttackEnd()
    {
        ec.hit = false;
    }
}
