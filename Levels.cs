using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    public static int NumberLevel = 1;

    public static int NumberLevel1
    {
        get => NumberLevel;
        set => NumberLevel = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Level " + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
