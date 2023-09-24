using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Debug = System.Diagnostics.Debug;

public class EmmaController : MonoBehaviour
{
    protected Animator animEmma;
    public GameObject collederForWalk;
    public Rigidbody RBEmma;

    NavMeshAgent agent;
    int i;
    public List<Transform> targets;
    public bool isMove = true;
    public bool isCollectBool = false;
    public float timer = 0;
    public float aRD; //удалить потом
    public float aSD; //удалить потом



    // Start is called before the first frame update
    void Start()
    {
        animEmma = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        RBEmma = GetComponent<Rigidbody>();
        agent.stoppingDistance = 0.03f;
        TargetUpdate();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Sit"))
        {
            collederForWalk.GetComponent<Collider>().enabled = false;
            // agent.isStopped = false;
            //RBEmma.velocity = new Vector3 (0,0,0);

        }
        else
        {
            collederForWalk.GetComponent<Collider>().enabled = true;
            
           // agent.isStopped=true;
        }


          // && (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect"))
        if (agent!= null && isCollectBool)
        {
            agent.enabled = true;
            //  aRD = agent.remainingDistance;
            //if (Mathf.Abs(agent.transform.position.z - agent.pathEndPosition.z) < 0.3 || Mathf.Abs(agent.transform.position.x - agent.pathEndPosition.x)  < 0.3)
            if (agent.remainingDistance <= agent.stoppingDistance && !animEmma.GetCurrentAnimatorStateInfo(0).IsName("Sit"))   
            {
                animEmma.SetBool("isCollect", true);
                timer += Time.deltaTime;

                
                agent.SetDestination(gameObject.transform.position);
                agent.updateRotation = false;
                //animEmma.SetBool("isCollect", false);

                if (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") && timer >= 2f)
                {
                    animEmma.SetBool("isCollect", false);
                    agent.updateRotation = true;
                    timer = 0;
                    TargetUpdate();
                }




                //agent.SetDestination(gameObject.transform.position);
                // agent.isStopped = false;
                //agent.updateRotation = false;

                // aRD = agent.remainingDistance;
                // aSD = agent.stoppingDistance;

                //if (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") && timer >= 2f)
                //{

                //    //  agent.updateRotation = true;
                //  //  agent.isStopped = true;

                //    animEmma.SetBool("isCollect", false);
                //    timer = 0;
                //    TargetUpdate();

                //}
            }
            else 
            {
                animEmma.SetBool("isCollect", false);
            }
            //else if(animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect"))
            //{
            //    agent.SetDestination(gameObject.transform.position);
            //    agent.updateRotation = false;
            //}
            //else if (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") && timer >= 2f)
            //{
            //    animEmma.SetBool("isCollect", false);
            //    agent.updateRotation = true;
            //    timer = 0;
            //    TargetUpdate();
            //}

            // aSD = agent.stoppingDistance;


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
        
    }
    
    public void isCollect()
    {
        
            isCollectBool = !isCollectBool;
            
        
    }
    //public void collectEnd(string message)
    //{
    //    if(message.Equals("collectEnd"))
    //    {
    //        aSD = 5555f;
    //    }
    //}
}
