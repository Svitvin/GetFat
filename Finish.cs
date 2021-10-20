using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
     private TextMeshPro _textMeshPro;
     private Levels _levels;

     void Awake()
     {
         _levels = GameObject.Find("Levels").GetComponent<Levels>();
         _textMeshPro = GameObject.Find("WinAndLoseText").GetComponent<TextMeshPro>();
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Levels.NumberLevel += 1;
            _textMeshPro.text = "You Win!!!";
            await Task.Delay(3000);
            LevelSetup.cameraPointsCounter = 0;
            SceneManager.LoadScene("Level " + 1);
        }
    }
}
