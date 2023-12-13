using System.Collections.Generic;
using UnityEngine;
public class Room
{
    public class SpawnPoint
    {
        public Vector3 pos;
        public string mobName;
        public bool hasHeal;
        public SpawnPoint(int x, int z, string name, bool _hasHeal = false, int y = 0)
        {
            pos = new Vector3(x, y, z);
            mobName = name;
            hasHeal = _hasHeal;
        }
    }

    public string roomShape;
    public List<SpawnPoint> spawnPoints;
}
