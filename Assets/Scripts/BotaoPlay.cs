using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    // Carrega a cena do jogo
    public void CarregarJogo()
    {
        Debug.Log("CarregarJogo foi chamado!");
        SceneManager.LoadScene("Jogo"); // Nome da cena deve ser igual ao que está no Project
    }

    // Carrega o menu principal
    public void CarregarMenu()
    {
        Debug.Log("CarregarMenu foi chamado!");
        SceneManager.LoadScene("Menu"); // Nome da cena do menu
    }

    // Fecha o jogo (funciona em build, não no editor)
    public void SairDoJogo()
    {
        Debug.Log("Sair do jogo foi chamado!");
        Application.Quit();
    }
}
