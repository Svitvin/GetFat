using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private Image panel;
    /*void Awake()
    {
        _textMeshPro = GameObject.Find("WinAndLoseText").GetComponent<TextMeshPro>();
        panel = GameObject.Find("Panel").GetComponent<Image>();
    }*/
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*_textMeshPro.text = "Paused";
            panel.color = new Color(0.5f,0.5f,0.5f,0.5f);*/
            Time.timeScale = 0;
        }
    }
}
