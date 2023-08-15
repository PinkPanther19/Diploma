using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera Player_Cam;
    private Ray _ray;
    private RaycastHit _hitRaycast;
    [SerializeField] private float _maxDistanceRay;
    public Camera MainCam;
    public List<GameObject> Cinemachine_cam;
    public CharacterController controller;
    public bool isSit = false;
    private float rotat;
    public CinemachineVirtualCamera CVC;
    
    public GameObject InteractiveText;
    public GameObject KeyText;
    private string textInter = " "; 
    public Inventory inventory;
    public Item ItemName;
    public bool isDialogue = false;
    //[SerializeField] private GameObject Player;

    void Start()
    {
        EnableCinemaCam(0);
        
        
    }
    void Awake()
    {
       // EnableCinemaCam(2);
       // StopPlayer();
       // isSit = true;
    }
    private void Update()
    {
        Ray();
        DrawRay();
        //isDialogue = GameObject.Find("Dialogue Manager (1)").GetComponent<DialogueSystemController>.isDialog;
    }

    private void Ray()
    {
        _ray = Player_Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


    }

    private void DrawRay()
    {
        if(Physics.Raycast(_ray, out _hitRaycast, _maxDistanceRay)) //луч столкнулся
        {
           // Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.blue);
           
            if(_hitRaycast.collider.tag == "Chair")
            {
                textInter = "Sit";
                InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            }
            // else if (_hitRaycast.collider.tag == "Item")
            // {
            //     textInter = "Take";
            //     InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            // }



            if(_hitRaycast.collider.tag == "Chair")
            {
                //textInter = "[E]";
                KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[LBM]";
            }
           /* else if (_hitRaycast.collider.tag == "Item")
            {
                KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[E]";
            } */




            if(_hitRaycast.collider.tag == "Item" && Input.GetKey(KeyCode.F)) //поднять предмет
            {
                
                    inventory.startItems.Add(_hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO);
                    ItemName = _hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO;
                    Destroy(_hitRaycast.collider.gameObject);
               
            }

            
            
            if(Input.GetMouseButton(0)) //ЛКМ
            {
                if(_hitRaycast.collider.tag == "Chair" && isSit == false) //Сесть
                {
                    Sit();

                }
               
            }
            
            
        }
        else if(_hitRaycast.transform == null) //луч не столкнулся
        {
          //  Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.red);
            textInter = "";
            InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }

        if(Input.GetMouseButton(1)) //отменяем действия 
        {
            if(isSit == true) //встать со стула
            {
                funcSitOFF();
            }
        }
    }

    private void EnableCinemaCam(int k)
    {
        Cinemachine_cam.ForEach(i => i.SetActive(false));
        Cinemachine_cam[k].SetActive(true);

    }
    private void StopPlayer()
    {
        controller.enabled = false;
    }
    private void StartPlayer()
    {
        controller.enabled = true;
    }

    public void Sit()
    {
        Cinemachine_cam[1].transform.position = new Vector3(_hitRaycast.collider.transform.position.x, 0.74f,_hitRaycast.collider.transform.position.z);

        rotat = _hitRaycast.collider.transform.eulerAngles.y;
        CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = rotat;

        EnableCinemaCam(1);
        StopPlayer();
        isSit = true;

    }
    public void funcSitOFF()
    {
        EnableCinemaCam(0);
        StartPlayer();
        isSit = false;
    }

    public void DialogON()
    {
        isDialogue = true;
        EnableCinemaCam(2);
        StopPlayer();
    }

    public void DialogOFF()
    {
        if(isSit == true)
        {
            EnableCinemaCam(1);
        }
        else
        {
            EnableCinemaCam(0);
        }
        StartPlayer();
        isDialogue = false;
    }
    
    public void StartCatScene()
    {
        
        
            EnableCinemaCam(3);
            StopPlayer();
        
       
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("EndMap")) 
        {
            StopPlayer();
            rotat = other.gameObject.collider.transform.eulerAngles.y;
            CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = rotat;

        }
    }
    public void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("EndMap")) 
        {
            StartPlayer();
            
        }
    }

}
