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
   
    public List<Transform> targets;
    public bool isMove = true;
    public bool isCollectBool = false;
    public float timer = 0;
    public float aRD; //удалить потом
    public float aSD; //удалить потом
    public bool EmmaIsDialog = false;
    public float timer2 = 0;
    public Transform Player;
    public bool isCatScene = false;
    public Transform TargetForEmma;


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



        if (agent != null && isCollectBool && !isCatScene && (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect")))
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
        else if(!isCollectBool && !isCatScene && (animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animEmma.GetCurrentAnimatorStateInfo(0).IsName("Collect"))) //код сработает только 1 раз, т.к. в нем включится другая анимация
        {
            animEmma.SetBool("isCollect", false);
            if(animEmma.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                agent.updateRotation = true;
                agent.SetDestination(Player.position);
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.SetDestination(gameObject.transform.position);
                    animEmma.SetBool("isIdle", true);
                    timer2 = 0f;
                    TargetUpdate();
                }
            }
           
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

    public void EmmaDialogON()
    {
        EmmaIsDialog = true;
        isCollectBool = false;
    }
    public void EmmaDialogOFF()
    {
        TargetUpdate();
        EmmaIsDialog = false;
        isCollectBool = true;
        animEmma.SetBool("isIdle", false);
    }

    public void goToPlayerForCatScene()
    {
        animEmma.SetBool("isCollect", false);
        isCollectBool = false;
        isCatScene = true;
        animEmma.SetBool("isIdle", true);
        gameObject.transform.position = TargetForEmma.position;
        
        
        gameObject.transform.rotation = TargetForEmma.rotation;
        agent.SetDestination(gameObject.transform.position);

    }

    //public void collectEnd(string message)
    //{
    //    if(message.Equals("collectEnd"))
    //    {
    //        aSD = 5555f;
    //    }
    //}
}
