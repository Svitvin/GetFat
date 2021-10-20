using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] HeroMovement hm;
    [SerializeField] private GameObject Hero;
    [SerializeField] private Rigidbody heroRigidbody;
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private TextMeshPro _textMeshPro;
    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Restart _restart = new Restart();
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hm.AggresionSpeed = 0;
            hm.StandartSpeed = 0;
            heroRigidbody.isKinematic = false;
            hm.enabled = false;
            _cinemachineBrain.enabled = false;
            _textMeshPro.text = "You Lose";
            await Task.Delay(3000);
            _restart.RestartLevelButon();
        }
    }
}
