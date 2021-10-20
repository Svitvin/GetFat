using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPoint : RoadObjectPoint
{
    public override void SetEntity()
    {
        GameObject boxPrefab = ObjectsPool.instance.GetBoxPrefab();
        Instantiate(boxPrefab, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
