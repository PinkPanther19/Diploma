using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //private ChromaticAberration PP_CA;
    public CharacterController controller;

    public AudioSource walk_sound;
    private Vector3 p2;
    

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    public float walkSpeed = 4f;
    public float runSpeed = 5f;
    public float height_normal = 2f;
    public float height_squat = 1f;
    private bool squat = false;
    private float t = 0f;
    float x, z;
    Vector3 velocity; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;  
    public LayerMask groundMask;
    bool isGrounded;
    public bool isMove = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.enabled == true && isMove == true)
        {

            
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            //ходьба
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            //звук шагов и бега
            if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && (!Input.GetKey(KeyCode.LeftShift)) && isGrounded && transform.position!=p2)
            {
                walk_sound.pitch = 1.5f;
                if(!walk_sound.isPlaying)
                {
                    walk_sound.Play();
                }
            }
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.LeftShift)) && isGrounded && transform.position!=p2)
            {
                walk_sound.pitch = 2.4f;
                if(!walk_sound.isPlaying)
                {
                    walk_sound.Play();
                }
            }
            else
            {
                walk_sound.Stop();
            }
            p2 = transform.position;

            //гравитация
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            

            //прыжок
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //бег
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }

            //приседание
            if(Input.GetKey(KeyCode.LeftControl))
            {
                if(squat == false) //приседает
                {
                    t +=1f*Time.deltaTime;
                    controller.height = Mathf.Lerp(height_normal, height_squat, t);

                    if(controller.height - height_squat < 0.06f)
                    {
                        controller.height = height_squat;
                        squat = true;
                        t = 0f;
                    }
                }
            }
                else if (squat == true)//встает
                {
                    t +=1f*Time.deltaTime;
                    controller.height = Mathf.Lerp(height_squat, height_normal, t);
                    
                    if(controller.height - height_normal < 0.06f)
                    {
                        controller.height = height_normal;
                        squat = false;
                        t = 0f;
                    }
                }
            
            
        }
        else
        {
            walk_sound.Stop();

            //гравитация
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void StopJump()
    {
        isGrounded = false;
    }
    public void StartJump()
    {
        isGrounded = true;
    }
}
