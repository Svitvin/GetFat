using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField]private float[] chanse;
// Start is called before the first frame update
    void Start()
    {
        gameObjects[Randomizer.RandomizeByChancesArr(chanse)].active = true;
    }
}
