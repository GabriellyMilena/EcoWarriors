using UnityEngine;

public class BotaoSairDoMenu : MonoBehaviour
{
    // Esse método será chamado quando o botão "Sair" do menu for clicado
    public void SairDoMenu()
    {
        Debug.Log("Saindo do jogo a partir do Menu...");
        Application.Quit(); // Só funciona no build, não dentro do editor
    }
}
