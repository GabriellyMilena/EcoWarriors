using UnityEngine;

public class BotaoSairDoMenu : MonoBehaviour
{
    public void SairDoMenu()
    {
        Debug.Log("Saindo do jogo a partir do Menu...");
        Application.Quit();
    }
}
