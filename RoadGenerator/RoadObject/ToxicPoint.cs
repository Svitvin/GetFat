using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPoint : RoadObjectPoint
{
    public override void SetEntity()
    {
        GameObject _toxicPrefab = ObjectsPool.instance.GetToxicPrefab();
        Instantiate(_toxicPrefab, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
