using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatnessController : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer meshRenderer;
    [SerializeField] GameObject model;
    [SerializeField] float fatness;
    [SerializeField] DynamicBone _dynamicBone;

    float targetFatness;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        model = GameObject.Find("MainChar");
        _dynamicBone.enabled = false;
    }

    public void ChangeFatness(float change)
    {

        if (targetFatness + change >= 0 && targetFatness + change <= 100)
        {
            targetFatness = targetFatness + change;
            /*StopCoroutine("Change");
            StartCoroutine(Change(fatness + change));*/

            Debug.Log(targetFatness);

            if (targetFatness > 50)
            {
                if (!_dynamicBone.enabled)
                {
                    _dynamicBone.enabled = true;

                }
            }
            else 
            {
                _dynamicBone.enabled = false;

            }

            //model.transform.localScale += new Vector3(1, 0.8f, 1) * 0.04f * change;

            //meshRenderer.SetBlendShapeWeight(0, fatness);
        }
    }


    private void Update()
    {
        fatness += (targetFatness - fatness) * 3 * Time.deltaTime;
        model.transform.localScale += new Vector3(1, 0.8f, 1) * 0.005f * (targetFatness - fatness);
        meshRenderer.SetBlendShapeWeight(0, fatness);
    }


    IEnumerator Change(float newFatness)
    {
        while(Mathf.Abs(newFatness - fatness) >=0.1f)
        {
            fatness += (newFatness - fatness) * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
