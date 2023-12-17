using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public class SpawnPoint
    {
        public Vector3 pos;
        public int index;
        public bool hasHeal;
        public SpawnPoint(int x, int z, int _index, bool _hasHeal = false, int y = 1)
        {
            pos = new Vector3(x, y, z);
            index = _index;
            hasHeal = _hasHeal;
        }
    }

    public string roomShape;
    public List<List<SpawnPoint>> spawnPoints = new List<List<SpawnPoint>>();
}
