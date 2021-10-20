using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapModel : MonoBehaviour
{
    [SerializeField] GameObject ragdoll;
    [SerializeField] GameObject notRagdoll;
    [SerializeField] private bool temp;

    private void OnTriggerEnter(Collider other)
    {
        if (temp)
        {
            if (other.CompareTag("Player"))
            {
                ragdoll.active = true;
                notRagdoll.active = false;
                GetComponent<Collider>().enabled = false;

                StartCoroutine(TimeSlow());
            }
        }
        else if (other.CompareTag("Pyla"))
        {
            ragdoll.active = true;
            notRagdoll.active = false;
            GetComponent<Collider>().enabled = false;

            StartCoroutine(TimeSlow());
        }
        else
        {
            if (other.CompareTag("Player") || other.gameObject.CompareTag("RagdollPuncher"))
            {
                ragdoll.active = true;
                notRagdoll.active = false;
                GetComponent<Collider>().enabled = false;

                StartCoroutine(TimeSlow());
            }
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
