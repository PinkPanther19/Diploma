using UnityEngine;
using System.Collections;

public class DelayedActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    private float minDelay = 10f;
    private float maxDelay = 20f;

    void Start()
    {
        
    }

    private IEnumerator ActivateObject()
    {
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        objectToActivate.SetActive(true);
    }

    public void StartDialog()
    {
        StartCoroutine(ActivateObject());
    }
}
