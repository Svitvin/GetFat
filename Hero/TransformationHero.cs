using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationHero : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private SkinnedMeshRenderer bodySkinnedMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer shortsSkinnedMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer bodySkinnedMeshRendererRig;
        [SerializeField] private SkinnedMeshRenderer shortsSkinnedMeshRendererRig;
    [SerializeField] private Material[] materials;
    private int toxin;

    private Color colorStart;
    private Color colorFinish;
    
    
    public int Toxin
    {
        get => toxin;
        set => toxin = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        colorFinish = materials[1].color;
        colorStart =  materials[0].color; 
        Toxin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = toxin * 5;
        float transformStadi = toxin*5;
        if (transformStadi > 100)
        {
            transformStadi = 100;
        }
        float colorTransformStadi = transformStadi/100f;
        bodySkinnedMeshRenderer.SetBlendShapeWeight(0, transformStadi);
        bodySkinnedMeshRenderer.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(colorStart, colorFinish, colorTransformStadi);
        shortsSkinnedMeshRenderer.SetBlendShapeWeight(0, transformStadi);
        
                bodySkinnedMeshRendererRig.SetBlendShapeWeight(0, transformStadi);
                bodySkinnedMeshRendererRig.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(colorStart, colorFinish, colorTransformStadi);
                shortsSkinnedMeshRendererRig.SetBlendShapeWeight(0, transformStadi);
    }
        
}
