using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Room room;
    public GameObject[] enemyPrefabs;

    public float randomPosXmin;
    public float randomPosXmax;
    public float randomPosZmin;
    public float randomPosZmax;

    private List<Enemy> enemiesToBeGenerated = new List<Enemy>();

    
    // Start is called before the first frame update
    void Start()
    {
        enemyGenerator();
        
        for(int i = 0; i < enemiesToBeGenerated.Count; i++)
        {
            instantiateEnemy(enemiesToBeGenerated[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void enemyGenerator()
    {
        int cost = room.enemyCost;
        int tier = room.enemyTier;
        while(cost > 0)
        {
            for (int i = tier; i > 0; i--)
            {
                if (cost - i >= 0)
                {
                    enemiesToBeGenerated.Add(new Enemy("Doll", tier, i));
                    cost -= i;
                }
            }
        }
        
    }

    private void instantiateEnemy(Enemy enemy)
    {
        int cost = enemy.enemyCost;
        int tier = enemy.enemyTier;
        GameObject enemyObject = Instantiate(enemyPrefabs[cost - 1]);
        float randomPosX = UnityEngine.Random.Range(randomPosXmin, randomPosXmax);
        float randomPosZ = UnityEngine.Random.Range(randomPosZmin, randomPosZmax);
        enemyObject.transform.position = new Vector3(randomPosX, enemyObject.transform.position.y, randomPosZ);

    }
}
