using UnityEngine;

public class CursorON : MonoBehaviour
{
    void Start()
    {
        // Включаем курсор, если он выключен
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }

    void Update()
    {
        // Включаем курсор, если он выключен
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
