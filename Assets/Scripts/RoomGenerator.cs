using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Room room;
    public GameObject[] enemyPrefabs;
    private List<Enemy> enemiesToBeGenerated = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        enemyGenerator();
        
        for(int i = 0; i < enemiesToBeGenerated.Count; i++)
        {
            Debug.Log(enemiesToBeGenerated[i].enemyName + enemiesToBeGenerated[i].enemyCost.ToString() + " " + enemiesToBeGenerated[i].enemyTier.ToString());
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

    private void instantiateEnemy(GameObject enemyObject)
    {

    }
}
