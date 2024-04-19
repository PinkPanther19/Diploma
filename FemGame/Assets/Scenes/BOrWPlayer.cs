using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BOrWPlayer : MonoBehaviour
{
    public string MyColor = "";
    public GameObject GameManager;
    public GameManager GameManagerScript;
    public Camera cam;

    public Ray rayGeneral;
    public Vector3 impact1;
    public string ColorRN;

    public GameObject TopText;
    
    public float x, z;
    public bool start = false;


    void Start()
    {


        MyColor = "Black";
        //GameManager.GetComponent<GameManager>().enabled = true;



    }

    void Update()
    {

        if (start)
        {
            ColorRN = GameManagerScript.StrPlayerColorRN;


            if (ColorRN == MyColor)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    MyTurn();
                }


            }
            else if (GameManagerScript.StrPlayerColorRN == "White") //// Ход Эммы
            {


                StartCoroutine(EmmaMove());

            }

        }





    }

    public void StartGameReversi()
    {
        MyColor = "Black";
        GameManager.GetComponent<GameManager>().enabled = true;
        GameManager.GetComponent<GameManager>().enabled = true;
        start = true;
    }
    IEnumerator EmmaMove()
    {
        yield return new WaitForSeconds(3);
        if (ColorRN == "White")
        {
            x = Random.Range(-10f, 10f);
            z = Random.Range(-10f, 10f);
            impact1 = new Vector3(Mathf.Round(x * 10) / 10, 0f, Mathf.Round(z * 10) / 10);

            GameManagerScript.boolToGo = true;
            GameManagerScript.impact = impact1;
            Debug.Log(impact1);
        }
        else
        {
            yield break;
        }
        
    }


    public void MyTurn()
    {
     
            rayGeneral = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); //Поменять на центр камеры
        if (Physics.Raycast(rayGeneral, out RaycastHit hitInfo))
        {
            impact1 = hitInfo.point;
            Debug.Log(impact1);
    
            GameManagerScript.boolToGo = true;
            GameManagerScript.impact = impact1;
        }

    }




    public void GetTurn(Vector3 impactFromPlayer)
    {
       
        GameManagerScript.boolToGo = true;

        GameManagerScript.impact = impactFromPlayer;

    }



}



