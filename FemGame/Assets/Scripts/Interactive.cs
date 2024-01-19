using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Interactive : MonoBehaviour
{
    [SerializeField] public Player Player; //Это ссылка на скрипт PLayer
    [SerializeField] public CameraController CameraController;
    [SerializeField] private Camera Player_Cam;
    private Ray _ray;
    private RaycastHit _hitRaycast;
    [SerializeField] private float _maxDistanceRay;
    public Camera MainCam;
    public List<GameObject> Cinemachine_cam;
    public CharacterController controller;
    public bool isSit = false;
    //public bool isRadio = false;
    private float rotat;
    public CinemachineVirtualCamera CVC;
  
    
    public GameObject InteractiveText;
    public GameObject KeyText;
    private string textInter = " "; 
    //public Inventory inventory;
    //public Item ItemName;
    public bool isDialogue = false;

    
    private Vector3 moveDirection = Vector3.zero;
    //private bool isMoving = true;
    //private float distanceToTravel = 3f;
    //private float currentDistance = 0f;
    public float gravity = -9.81f;
    public Transform Center;
    public float rotationSpeed = 5f;
    public bool nb = false;
    private float movementSpeed = 1f; 
    private float distanceThreshold;

    public AudioSource Grass_audio;
    public int CamNumber;

    private Outline outline;

    private GameObject hitObject;
    //[SerializeField] private GameObject Player;

    void Start()
    {
       // EnableCinemaCam(0);
        controller = GetComponent<CharacterController>();
        
        
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

        if(nb==true) //Если игрок ушел за карту, то он возвращается и идет в сторону стола
        {
             Vector3 direction = Center.position - transform.position;
     
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f), rotationSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, Center.position);
            if ((distanceThreshold - distance) < 4f)
            {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }
            else
            {
                StartPlayer();
                nb=false;
            }
        }
    }   
        
    

    private void Ray()
    {
        _ray = Player_Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hitRaycast, _maxDistanceRay)) //луч столкнулся
        {
            hitObject = _hitRaycast.collider.gameObject;
            // Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.blue);

            if (_hitRaycast.collider.tag == "Chair")
            {
                textInter = "Sit";
                InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            }
            // else if (_hitRaycast.collider.tag == "Item")
            // {
            //     textInter = "Take";
            //     InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            // }


            if (_hitRaycast.collider.tag == "Chair")
            {
                //textInter = "[E]";
                KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[LBM]";
            }
            /* else if (_hitRaycast.collider.tag == "Item")
             {
                 KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[E]";
             } */


            //if (_hitRaycast.collider.tag == "Radio")
            //{
            //    if(isRadio)
            //    {
            //        KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[RBM]";
            //    }
            //    else
            //    {
            //        KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "[LBM]";
            //    }
            //    textInter = "Radio";
            //    InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            //}

            if(_hitRaycast.collider.tag == "Branch")
            {
                hitObject = _hitRaycast.collider.gameObject;
                outline = _hitRaycast.collider.gameObject.GetComponent<Outline>();
                outline.enabled = true;

            }
            else
            {
                if(outline != null) 
                {
                    outline.enabled = false;
                }
                
            }
            

            // if(_hitRaycast.collider.tag == "Item" && Input.GetKey(KeyCode.F)) //поднять предмет
            // {

            //         inventory.startItems.Add(_hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO);
            //         ItemName = _hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO;
            //         //Destroy(_hitRaycast.collider.gameObject);

            // }



            if (Input.GetMouseButton(0)) //ЛКМ
            {
                if (_hitRaycast.collider.tag == "Chair" && isSit == false) //Сесть
                {
                 
                    Sit();


                }
                //else if (_hitRaycast.collider.tag == "Radio" && !isRadio)
                //{
                //    _hitRaycast.collider.gameObject.GetComponent<AudioSource>().Play();
                //    isRadio = true;
                //}


            }

            //if (Input.GetMouseButton(1))
            //{
            //    if (_hitRaycast.collider.tag == "Radio" && isRadio)
            //    {
            //        _hitRaycast.collider.gameObject.GetComponent<AudioSource>().Pause();
            //        isRadio = false;
            //    }
            //}

        }
        else if (_hitRaycast.transform == null) //луч не столкнулся
        {
            //  Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.red);
            textInter = "";
            InteractiveText.GetComponent<TMPro.TextMeshProUGUI>().text = textInter;
            KeyText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            
            if (outline != null) 
            {
                outline.enabled = false;
            }

        }

            if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.Space)) //отменяем действия 
            {
                if (isSit == true) //встать со стула
                {
                    funcSitOFF();
                }
            }   
    }

    private void EnableCinemaCam(int k)
    {
        Cinemachine_cam.ForEach(i => i.SetActive(false));
        Cinemachine_cam[k].SetActive(true);
        CamNumber = k;

    }
    private void StopPlayer()
    {
        //controller.enabled = false;
        Player.isMove = false;
        CameraController.enabled = false;
    }
    private void StartPlayer()
    {
        //controller.enabled = true;
        Player.isMove = true;
        CameraController.enabled = true;
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
        //EnableCinemaCam(2);
        StopPlayer();
    }

    public void DialogOFF()
    {
        if(isSit == true)
        {
            CamOnEmma();
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

    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("EndMap")) 
        {
            Debug.Log("Столкнулась");
            StopPlayer();
            nb = true;
            distanceThreshold = Vector3.Distance(transform.position, Center.position);
        }
        if(other.gameObject.CompareTag("Map"))
        {
            Debug.Log("не Столкнулась");
            StartPlayer();
            nb=false;
        }
        if(other.gameObject.CompareTag("Grass"))
        {
            if(Grass_audio.isPlaying == false)
            Grass_audio.Play();
        }
    }

    //public void AddItem ()
    //{
    //    //inventory.startItems.Add(gameObject.GetComponent<Ite_so_Holder>().itemSO);
    //    //ItemName = gameObject.GetComponent<Ite_so_Holder>().itemSO;
    //    //Destroy(gameObject);
    //    inventory.startItems.Add(_hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO);
    //    ItemName = _hitRaycast.collider.gameObject.GetComponent<Ite_so_Holder>().itemSO;
    //}

    public void CamOnEmma()
    {
        EnableCinemaCam(4);
    }
    
    public void idleCam()
    {
        EnableCinemaCam(0);
    }
}
