using UnityEngine;

public class DebugBotoesGameSir : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i <= 19; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.JoystickButton0 + i)))
            {
                Debug.Log("JoystickButton " + i + " pressionado");
            }
        }
    }
}
