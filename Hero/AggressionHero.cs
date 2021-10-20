using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AggressionHero : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private int aggresion ;

    public int Aggresion
    {
        get => aggresion;
        set => aggresion = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        aggresion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = Aggresion * 10;
    }
}
