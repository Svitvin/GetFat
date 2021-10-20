using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SwapHullk : MonoBehaviour
{
    [SerializeField] GameObject ragdoll;
    [SerializeField] GameObject notRagdoll;
    [SerializeField] private Rigidbody hero;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Animator _animator;
    [SerializeField] HeroMovement hm;
    private Restart _restart = new Restart();
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private TextMeshPro _textMeshPro;
    // Start is called before the first frame update
    
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pyla"))
        {


            StartCoroutine(TimeSlow());
            _animator.SetBool("IsShot", true);
            for (float i = 10;i > 0; i-=1)
            {
                hm.AggresionSpeed = hm.AggresionSpeed -0.2f;
                hm.StandartSpeed = hm.StandartSpeed - 0.2f;
                await Task.Delay(50);
            }

            Panel.active = false;
            hero.constraints = RigidbodyConstraints.FreezeAll;
            hm.TempStart = false;
            _cinemachineBrain.enabled = false;
            _textMeshPro.text = "You Lose";
            await Task.Delay(3000);
            _restart.RestartLevelButon();
        }
    }

    IEnumerator TimeSlow()
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
