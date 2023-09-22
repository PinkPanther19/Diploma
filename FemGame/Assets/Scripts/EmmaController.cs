using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;


public class EmmaController : MonoBehaviour
{
    protected Animator animEmma;
    public GameObject collederForWalk;

    NavMeshAgent agent;
    int i;
    public List<Transform> targets;
    public bool isMove = true;
    public bool isCollectBool = false;
    public float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        animEmma = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.1f;
        TargetUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
        {
            collederForWalk.GetComponent<Collider>().enabled = false;
        }
        else
        {
            collederForWalk.GetComponent<Collider>().enabled = true;
        }


          // && (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect"))
        if (agent!= null && isCollectBool)
        {
            //if (Mathf.Abs(agent.transform.position.z - agent.pathEndPosition.z) < 0.3 || Mathf.Abs(agent.transform.position.x - agent.pathEndPosition.x)  < 0.3)
            if(agent.remainingDistance <= agent.stoppingDistance)   
            {
                timer += Time.deltaTime;
                animEmma.SetBool("isCollect", true);

                if (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    animEmma.SetBool("isCollect", false);
                    TargetUpdate();
                }
            }


            
            
                agent.SetDestination(targets[i].position);
            
               // Debug.Log("Должна идти");
            
            
        }
        //else
        //{
        //    Debug.Log("агента нет");
        //}
    }

    public void isSitEmma()
    {
        animEmma.SetBool("isSit", false);
        
    }

    void TargetUpdate()
    {
        i = Random.Range(0, targets.Count);
        timer = 0;
    }
    
    public void isCollect()
    {
        
            isCollectBool = !isCollectBool;
            
        
    }
}
