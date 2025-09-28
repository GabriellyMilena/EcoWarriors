using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    // Chave usada para salvar o highscore
    private string highscoreKey = "Highscore";

    // Reinicia a cena atual
    public void ReiniciarJogo()
    {
        Time.timeScale = 1; // Garante que o tempo volte ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
