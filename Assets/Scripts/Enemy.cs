using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyName;
    public int enemyTier;
    public int enemyCost;
    public int enemyHP_Max;
    public int enemyHP_Now;
    public bool hasHpReward;
    public bool isBoss;
    public Enemy(string _name, int _tier, int _cost, bool _hasHpReward = false, bool _isBoss = false)
    {
        enemyName = _name;
        enemyTier = _tier;
        enemyCost = _cost;
        hasHpReward = _hasHpReward;
        isBoss = _isBoss;

        enemyHP_Max = (enemyCost + 1) * 100;
        enemyHP_Now = enemyHP_Max;
    }
}
