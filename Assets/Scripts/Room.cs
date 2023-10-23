using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Room : ScriptableObject
{
    public int bonusCost;
    public int bonusTier;
    public int enemyCost;
    public int enemyTier;
    public int wave;
    public Room(int _bonusCost, int _bonusTier, int _enemyCost, int _enemyTier, int _wave)
    {
        bonusCost = _bonusCost;
        bonusTier = _bonusTier;
        enemyCost = _enemyCost;
        enemyTier = _enemyTier;
        wave = _wave;
    }
}
