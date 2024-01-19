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
    //public float timer = 0f;
    //public float max_timer = 10f;

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
            //if(animator.GetCurrentAnimatorStateInfo(0).IsName("Collect"))
            //{
            //    ikActive = false;
            //}
            //else
            //{
            //    ikActive = true;
            //}

            if(ikActive)
            { 
                if(lookWeightMax-lookWeightMin>0.05f)
                {
                    lookWeightMin = lookWeightMin + Speedvalue * Time.deltaTime;
                    //Debug.Log("эээ");
                }

                if (lookObj != null)
                    {
                    
                        animator.SetLookAtWeight(lookWeightMin);
                        animator.SetLookAtPosition(lookObj.position);
                    }
                //timer = timer + timer * Time.deltaTime;
                //Debug.Log("тру");
            }
            else
            {
                //Debug.Log("работает элс");
                if (lookWeightMin>0.05f)
                {
                    lookWeightMin = lookWeightMin - Speedvalue * Time.deltaTime;
                    if (lookObj != null)
                    {
                    
                        animator.SetLookAtWeight(lookWeightMin);
                        animator.SetLookAtPosition(lookObj.position);
                    }   
                }

                //if(timer>=max_timer)
                //{
                //    ikActive=false;
                //    timer = 0;
                //    Debug.Log("обнуление тайма");
                //}

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

    public void OnTriggerExit(Collider other) //ну это не работает
    {
        if (other.gameObject.CompareTag("Player")) 
        {
        ikActive = false;
        }
    }
}