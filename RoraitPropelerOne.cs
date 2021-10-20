using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoraitPropelerOne : MonoBehaviour
{
    [SerializeField] private GameObject propeler;
    [SerializeField] private GameObject propeler2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float y =  Time.deltaTime ;
        //Quaternion q = Quaternion.Euler(0,y ,0);
        propeler.transform.Rotate((new Vector3(0, 350, 0) * Time.deltaTime));
        propeler2.transform.Rotate((new Vector3(0, 0, 500) * Time.deltaTime));
    }
}
