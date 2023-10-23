using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy
{
    public string enemyName;
    public int enemyTier;
    public int enemyCost;
    public Enemy(string _name, int _tier, int _cost)
    {
        enemyName = _name;
        enemyTier = _tier;
        enemyCost = _cost;
    }
}
