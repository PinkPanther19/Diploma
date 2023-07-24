using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Скорость ходьбы")]
    public float walk_speed = 7f;
    [Header("Скорость бега")]
    public float run_speed = 11f;
    [Header("Сила прыжка")]
    public float jumpPower = 200f;
    [Header("Игрок на земле?")]
    public bool ground_bool = false;
    public Rigidbody rb;

    private float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = run_speed;
        }
        else
        {
            speed = walk_speed;

        }
        
        if(Input.GetKey(KeyCode.W))
        {
            //бег
            // if(Input.GetKey(KeyCode.LeftShift))
            // {
            //     transform.localPosition += transform.forward * run_speed * Time.deltaTime;
            // }
            // //шаг
            // else
            // {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            // }
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(ground_bool == true)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            ground_bool = true;
    }

    private void OnCollisionExit(Collision collision)
    {
            ground_bool = false;
    }
}
