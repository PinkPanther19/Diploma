using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuON : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
 
            //GameObject sceneSaveObject = GameObject.Find("Save System");
            //if(sceneSaveObject != null)
            //{
            //    Destroy(sceneSaveObject);
            //}
 
            SceneManager.LoadScene(0);
        }
    }

   
}

    //void LoadScene0()
    //{
    //    SceneManager.LoadScene(0);
    //}

