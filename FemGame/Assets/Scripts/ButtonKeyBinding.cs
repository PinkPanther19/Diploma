using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyBinding : MonoBehaviour
{
    private Button myButton;

    private void Start()
    {
        myButton = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myButton.onClick.Invoke();
        }
    }
}
