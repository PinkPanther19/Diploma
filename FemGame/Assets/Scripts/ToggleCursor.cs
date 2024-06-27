using UnityEngine;

public class ToggleCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        // �������� ������, ���� �� ��������
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        // �������� ������, ���� �� ��������
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }

        GameObject sceneSaveObject = GameObject.Find("Save System");
        if (sceneSaveObject != null)
        {
            Destroy(sceneSaveObject);
        }
    }
}
