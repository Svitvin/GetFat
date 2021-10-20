using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Levels _levels;
    public  void RestartLevelButon()
    {
        LevelSetup.cameraPointsCounter = 0;
        SceneManager.LoadScene("Level " + 1);
    }

}
