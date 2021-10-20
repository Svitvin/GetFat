using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerLevitation : MonoBehaviour
{
    [SerializeField] AnimationCurve yAxisLevitation;

    void Update()
    {
        transform.Rotate(Vector3.up, 50*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, yAxisLevitation.Evaluate(Time.time)*2 + 0.2f, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, yAxisLevitation.Evaluate(Time.time)*100 + 5f, transform.localScale.z);
    }
}
