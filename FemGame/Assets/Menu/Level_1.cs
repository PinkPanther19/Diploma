using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void PlayPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToScene_1()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToScene_2()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToScene_3()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToScene_4()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToScene_0()
    {
        SceneManager.LoadScene(0);
    }
}
