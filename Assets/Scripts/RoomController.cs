using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Room room;
    private GameManager gameManager;
    public GameObject[] enemyPrefabs;

    private float randomPosXmin;
    private float randomPosXmax;
    private float randomPosZmin;
    private float randomPosZmax;

    private List<Enemy> enemiesToBeGenerated = new List<Enemy>();

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        randomPosXmin = -5;
        randomPosXmax = 5;
        randomPosZmin = -5;
        randomPosZmax = 5;
    }
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
        int cost = room.enemyCapacity;
        int tier = room.enemyTier;
        while(cost > 0)
        {
            for (int i = tier; i > 0; i--)
            {
                if (cost - i >= 0)
                {
                    string name = "";
                    if (i == 1) name = "Doll";
                    else if (i == 2) name = "Skeleton";
                    else if (i == 3) name = "Bomb";

                    enemiesToBeGenerated.Add(new Enemy(name, tier, i));
                    cost -= i;
                }
            }
        }
        
        // Generate HP Reward
        if (room.hpRewardCapacity > 0)
        {
            int rewardCounter = 0;
            List<int> intList = new List<int>();
            for (int i = 0; i < enemiesToBeGenerated.Count; i++) intList.Add(i);
            List<int> indexHolder = new List<int>();
            while (rewardCounter < room.hpRewardCapacity)
            {
                int randomIndex = intList[UnityEngine.Random.Range(0, intList.Count)];
                intList.Remove(randomIndex);
                indexHolder.Add(randomIndex);
                rewardCounter++;
            }
            foreach (int index in indexHolder) enemiesToBeGenerated[index].hasHpReward = true;
        }
        // HP Reward Generated

    }

    private void instantiateEnemy(Enemy enemy)
    {
        int cost = enemy.enemyCost;
        int tier = enemy.enemyTier;
        GameObject enemyObject = Instantiate(enemyPrefabs[cost - 1]);
        float randomPosX = UnityEngine.Random.Range(randomPosXmin, randomPosXmax);
        float randomPosZ = UnityEngine.Random.Range(randomPosZmin, randomPosZmax);
        enemyObject.transform.position = new Vector3(randomPosX, enemyObject.transform.position.y, randomPosZ);
        enemyObject.GetComponent<EnemyController>().enemy = enemy;
    }
}
