using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum BossState
    {
        WAITING,
        MOVING,
        ATTACKING,
        STUNNED,
    }

    public Enemy enemy;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        if (enemy.isBoss) material.color = new Color(1, 0, 0);
        else if (enemy.hasHpReward) material.color = new Color(0, 1, 0);
        else material.color = new Color(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator BossMovement()
    {
        yield return null;
    }
}
