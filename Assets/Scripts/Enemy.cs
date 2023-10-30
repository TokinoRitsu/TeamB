using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyName;
    public int enemyTier;
    public int enemyCost;
    public bool hasHpReward;
    public Enemy(string _name, int _tier, int _cost, bool _hasHpReward = false)
    {
        enemyName = _name;
        enemyTier = _tier;
        enemyCost = _cost;
        hasHpReward = _hasHpReward;
    }
}
