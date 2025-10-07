using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    void Update()
    {
        string[] joysticks = Input.GetJoystickNames();
        if (joysticks.Length == 0 || string.IsNullOrEmpty(joysticks[0]))
            return;

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Botão X pressionado - Carregar jogo!");
            SceneManager.LoadScene("Dialogo");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("Botão O pressionado - Sair do jogo!");
            Application.Quit();
        }
    }
}
