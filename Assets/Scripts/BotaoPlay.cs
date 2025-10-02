using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    void Update()
    {
        // Carregar jogo: X do PS / A do Xbox / clique esquerdo do mouse
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Botão X ou clique esquerdo pressionado - Carregar jogo!");
            SceneManager.LoadScene("Dialogo");
        }

        // Sair do jogo: O do PS / B do Xbox / clique direito do mouse
        // Garantindo que só seja executado quando realmente apertado
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || (Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Botão O ou clique direito pressionado - Sair do jogo!");
            Application.Quit();
        }
    }
}
