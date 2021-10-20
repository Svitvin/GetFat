using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoint12 : RoadObjectPoint
{
    GameObject[] _wallPrefabs;
    float[] _chances;

    public override void SetEntity()
    {
        _wallPrefabs = ObjectsPool.instance.GetWallsPrefabs12();
        _chances = ObjectsPool.instance.GetWallsChances12();
        Instantiate(_wallPrefabs[Randomizer.RandomizeByChancesArr(_chances)], transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }

}
