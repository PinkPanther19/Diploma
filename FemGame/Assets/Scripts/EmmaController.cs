using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
//using Debug = System.Diagnostics.Debug;

public class EmmaController : MonoBehaviour
{
    protected Animator animEmma;
    public GameObject collederForWalk;
    public Rigidbody RBEmma;

    NavMeshAgent agent;
    int i = 1;
    int k = 0;
    public List<Transform> targets;
    public bool isMove = true;
    public bool isCollectBool = false;
    public float timer = 0;
    public float aRD; //удалить потом
    public float aSD; //удалить потом
    public bool EmmaIsDialog = false;
    public float timer2 = 0;



    // Start is called before the first frame update
    void Start()
    {
        animEmma = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        RBEmma = GetComponent<Rigidbody>();

        TargetUpdate();

    }

    // Update is called once per frame
    void Update()
    {
   
        if(!animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") && !animEmma.GetCurrentAnimatorStateInfo(0).IsName("Idle_Emma"))
        {
           // collederForWalk.GetComponent<Collider>().enabled = false;
           // agent.baseOffset = 0f;


        }
        else
        {
          //  collederForWalk.GetComponent<Collider>().enabled = true;
           // agent.baseOffset = 0.1f;

        }



        if (agent != null && isCollectBool && (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect")))
        {
            print(agent.remainingDistance);
            agent.SetDestination(targets[i].position);
            timer2 += Time.deltaTime;
            if ((agent.remainingDistance <= agent.stoppingDistance) && timer2>=1f)
            {
                print(agent.remainingDistance);
                animEmma.SetBool("isCollect", true);
                timer += Time.deltaTime;
                print(agent.remainingDistance);

                agent.SetDestination(gameObject.transform.position);
                agent.updateRotation = false;
                print(agent.remainingDistance);
                if (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") && timer >= 2f)
                {
                    print(agent.remainingDistance);
                    animEmma.SetBool("isCollect", false);
                    agent.updateRotation = true;
                    timer = 0;
                    TargetUpdate();
                }
                print(agent.remainingDistance);
            }
            else
            {
                animEmma.SetBool("isCollect", false);
                
            }

            agent.SetDestination(targets[i].position);
        }  

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

    public void EmmaDialog()
    {
        EmmaIsDialog = !EmmaIsDialog;
    }
    //public void collectEnd(string message)
    //{
    //    if(message.Equals("collectEnd"))
    //    {
    //        aSD = 5555f;
    //    }
    //}
}
