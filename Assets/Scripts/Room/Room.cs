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

    public class ItemSpawnPoint
    {
        public Vector3 pos;
        public int index;
        public ItemSpawnPoint(int x, int y, int z, int _index)
        {
            pos = new Vector3(x, y, z);
            index = _index;
        }
    }

    public string roomShape;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public List<ItemSpawnPoint> itemSpawnPoints = new List<ItemSpawnPoint>();

    public Room(string _roomShape, List<SpawnPoint> _spawnPoints, List<ItemSpawnPoint> _itemSpawnPoints)
    {
        roomShape = _roomShape;
        spawnPoints = _spawnPoints;
        itemSpawnPoints = _itemSpawnPoints;
    }
}
