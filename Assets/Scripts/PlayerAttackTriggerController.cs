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
    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }

    private IEnumerator DealDamage(float damage)
    {
        for (int i = 0; i < 10; i++) yield return null;
        foreach (Collider i in colliders)
        {
            Debug.Log(i.gameObject.name);
            EnemyController c = i.gameObject.GetComponent<EnemyController>();
            if (c != null)
            {
                if (c.enemyHP_Now - damage > 0)
                {
                    c.enemyHP_Now -= damage;
                    c.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = Color.red;
                    Vector3 originalPos = c.gameObject.transform.position;
                    for (int j = 0; j < 120; j++)
                    {
                        c.gameObject.transform.position = new Vector3(originalPos.x + Mathf.Sin(Time.time * 100f) * 0.1f, originalPos.y, originalPos.z);
                        yield return null;
                    }
                    c.gameObject.transform.position = originalPos;
                    c.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = Color.white;
                }
                else
                {
                    c.enemyHP_Now -= damage;
                }
                Debug.Log(i.gameObject.GetComponent<EnemyController>().enemyHP_Now);
            }
        }
        Destroy(gameObject);
    }
}
