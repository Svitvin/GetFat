using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    HeroMovement hm;
    private Rigidbody rg;
    Animator _animator;
    
    private TextMeshPro _textMeshPro;
    private Image panel;
    private TextMeshPro timeLast;

    void Awake()
    {
        hm = GameObject.Find("Hero").GetComponent<HeroMovement>();
        rg = GameObject.Find("Hero").GetComponent<Rigidbody>();
        _animator = GameObject.Find("Halk").GetComponent<Animator>();
        _textMeshPro = GameObject.Find("WinAndLoseText").GetComponent<TextMeshPro>();
        panel = GameObject.Find("Panel").GetComponent<Image>();
        timeLast = GameObject.Find("TimeLast").GetComponent<TextMeshPro>();
    }

    public async void OnBeginDrag(PointerEventData eventData)
    {
        /*if (_textMeshPro.text == "Paused")
        {
            Debug.Log("timeLast");
            for (int j = 3; j > 0; j--)
            {
                timeLast.text =""+ j;
                timeLast.fontSize = 1000;
                await Task.Delay(50);
                for (int i = 1000; i >500; i-=5)
                {
                    timeLast.fontSize = i;
                    await Task.Delay(1);
                }
            }
            timeLast.text ="";
        }*/
        /*_textMeshPro.text = "";*/
        panel.color = new Color(0,0,0,0);
        Time.timeScale = 1;
        hm.TempStart = true;
        await Task.Delay(50);
        rg.isKinematic = false;
        //hm.transform.Rotate(0,180,0);

        _animator.SetBool("Run", true);
    }

    public async void OnDrag(PointerEventData eventData)
    {

        await Task.Delay(10);
        Vector3 dragVector = eventData.delta;
        hm.InputMovement(dragVector);
    }
}
