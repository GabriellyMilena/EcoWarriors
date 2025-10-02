using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Necessário para Gamepad

public class PainelGameOver : MonoBehaviour
{
    // Chave usada para salvar o highscore
    private string highscoreKey = "Highscore";

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            // Quadrado (buttonWest) reinicia o jogo
            if (gamepad.buttonWest.wasPressedThisFrame)
            {
                ReiniciarJogo();
            }

            // Triângulo (buttonNorth) sai do jogo
            if (gamepad.buttonNorth.wasPressedThisFrame)
            {
                SairDoJogo();
            }
        }

        // Teclas de fallback para quem testa no teclado
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJogo();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SairDoJogo();
        }
    }

    // Reinicia a cena atual
    public void ReiniciarJogo()
    {
        Time.timeScale = 1; // Garante que o tempo volte ao normal
        SceneManager.LoadScene("Dialogo");
    }

    // Sai do jogo e reseta o highscore
    public void SairDoJogo()
    {
        // Remove a chave do highscore
        if (PlayerPrefs.HasKey(highscoreKey))
        {
            PlayerPrefs.DeleteKey(highscoreKey);
            PlayerPrefs.Save();
            Debug.Log("Highscore resetado.");
        }

        // Fecha o jogo
        Application.Quit();
        Debug.Log("Jogo Fechado.");
    }

    // Opcional: Função para verificar o highscore (para testes)
    public void MostrarHighscore()
    {
        int hs = PlayerPrefs.GetInt(highscoreKey, 0);
        Debug.Log("Highscore atual: " + hs);
    }
}
