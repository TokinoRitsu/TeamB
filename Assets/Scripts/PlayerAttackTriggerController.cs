using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTriggerController : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();
    private void Start()
    {
        StartCoroutine(DealDamage(GetComponentInParent<PlayerController>().playerAtk));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other)) colliders.Add(other);
    }

    private IEnumerator DealDamage(float damage)
    {
        for (int i = 0; i < 10; i++) yield return null;
        foreach (Collider i in colliders)
        {
            EnemyController c = i.gameObject.GetComponent<EnemyController>();
            if (c != null)
            {
                c.enemyHP_Now -= damage;
                Debug.Log(i.gameObject.GetComponent<EnemyController>().enemyHP_Now);
            }
        }
        Destroy(gameObject);
    }
}
