using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPoint : RoadObjectPoint
{
    public override void SetEntity()
    {
        GameObject coinPrefab = ObjectsPool.instance.GetCoinPrefab();
        Instantiate(coinPrefab, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
