using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class HeadController : MonoBehaviour
{

    protected Animator animator;
    public bool ikActive = false;
    public Transform lookObj = null;
    public float lookWeightMax = 2f;

    public float lookWeightMin;
    public float Speedvalue;

    void Start()
    {
        animator = GetComponent<Animator>();
        lookWeightMin = lookWeightMax;
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {

        if (animator)
        {

            if(ikActive)
            {
                if(lookWeightMax-lookWeightMin>0.05f)
                {
                    lookWeightMin = lookWeightMin + Speedvalue * Time.deltaTime;

                }

                if (lookObj != null)
                    {
                    
                        animator.SetLookAtWeight(lookWeightMin);
                        animator.SetLookAtPosition(lookObj.position);
                    }
            }
            else
            {
                if(lookWeightMin>0.05f)
                {
                    lookWeightMin = lookWeightMin - Speedvalue * Time.deltaTime;
                    if (lookObj != null)
                    {
                    
                        animator.SetLookAtWeight(lookWeightMin);
                        animator.SetLookAtPosition(lookObj.position);
                    }   
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
        ikActive = true;
        }
        // else
        // ikActive = false;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
        ikActive = false;
        }
    }
}