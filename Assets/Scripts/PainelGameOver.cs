using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Garante que o tempo volte ao normal
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("Jogo Fechado");
    }
}
