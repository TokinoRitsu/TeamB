using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public int enemyTier;
    public int enemyCost;
    public float enemyHP_Max;
    public float speed, attack;
    public float attack_range, attack_delay;
    public bool hasHpReward;
    public bool isBoss;
    public Enemy(int _tier, int _cost, bool _hasHpReward = false, bool _isBoss = false)
    {
        enemyTier = _tier;
        enemyCost = _cost;
        switch (enemyCost)
        {
            case 1:
                enemyName = "Doll";
                enemyHP_Max = 200;
                speed = 2;
                attack = 5;
                attack_range = 2;
                attack_delay = 2;
                break;

            case 2:
                enemyName = "Skeleton";
                enemyHP_Max = 300;
                speed = 2;
                attack = 7;
                attack_range = 5;
                attack_delay = 5;
                break;
            case 3:
                enemyName = "Bomber";
                enemyHP_Max = 400;
                speed = 3;
                attack = 10;
                attack_range = 1;
                attack_delay = 2;
                break;

            case 4:
                break;

            default:
                break;

        }

        hasHpReward = _hasHpReward;
        isBoss = _isBoss;
    }



    #region getter
    public int GetTier() { return enemyTier; }
    public float GetSpeed() { return speed; }
    public float GetAttack() { return attack; }
    public float GetAttack_Range() { return attack_range; }
    public float GetAttack_Delay() { return attack_delay; }
    public float GetEnemyCost() { return enemyCost; }
    #endregion

    #region setter
    public void SetTier(int tier) { this.enemyTier = tier; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetAttack(float attack) { this.attack = attack; }
    public void SetAttack_Range(float attack_range) { this.attack_range = attack_range; }
    public void SetAttack_Delay(float attack_delay) { this.attack_delay = attack_delay; }
    public void GetEnemyCost(int enemyCost) { this.enemyCost = enemyCost; }
    #endregion
}


