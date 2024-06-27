using UnityEngine;

public class CursorON : MonoBehaviour
{
    void Start()
    {
        // �������� ������, ���� �� ��������
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }

    void Update()
    {
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
