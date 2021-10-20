using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : RoadObjectPoint
{
    GameObject[] _enemyPrefabs;
    float[] _chances;

    public override void SetEntity()
    {
        _enemyPrefabs = ObjectsPool.instance.GetEnemiesPrefabs();
        _chances = ObjectsPool.instance.GetEnemiesChances();
        GameObject go = Instantiate(_enemyPrefabs[Randomizer.RandomizeByChancesArr(_chances)], transform.position, transform.rotation, transform.parent);
        go.transform.Rotate(Vector3.up * 180);
        Destroy(gameObject);
    }
}
