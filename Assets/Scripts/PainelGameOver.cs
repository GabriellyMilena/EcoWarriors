using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Necessário para Gamepad

public class PainelGameOver : MonoBehaviour
{
    private string highscoreKey = "Highscore";

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {

            if (gamepad.buttonWest.wasPressedThisFrame)
            {
                ReiniciarJogo();
            }
            if (gamepad.buttonNorth.wasPressedThisFrame)
            {
                SairDoJogo();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJogo();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SairDoJogo();
        }
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Dialogo");
    }

    public void SairDoJogo()
    {

        if (PlayerPrefs.HasKey(highscoreKey))
        {
            PlayerPrefs.DeleteKey(highscoreKey);
            PlayerPrefs.Save();
            Debug.Log("Highscore resetado.");
        }

        Application.Quit();
        Debug.Log("Jogo Fechado.");
    }

    public void MostrarHighscore()
    {
        int hs = PlayerPrefs.GetInt(highscoreKey, 0);
        Debug.Log("Highscore atual: " + hs);
    }
}
