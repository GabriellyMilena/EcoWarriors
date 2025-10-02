using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Novo Input System

public class DialogoController : MonoBehaviour
{
    public Text caixaDeTexto;

    private string[] falas = new string[]
    {
        "A Terra está em perigo: o lixo espacial se acumula em órbita!",
        "Satélites quebrados e toneladas de sucata ameaçam missões e até mesmo a vida no planeta.",
        "Para salvar o futuro, foi criada a Nave Ecológica: capaz de reciclar e destruir os detritos espaciais.",
        "Sua missão é clara: proteger a Terra e restaurar o equilíbrio ambiental.",
        "Use o analógico esquerdo para mover a nave.",
        "Aperte X para disparar.",
        "Aperte O para mudar a cor da nave.",
        "Recolha o item de escudo quando aparecer para se proteger dos impactos.",
        "Se colidir com o lixo espacial, perderá vida. Fique atento!",
        "Boa sorte, herói. O planeta conta com você!"
    };

    private int indice = 0;

    void Start()
    {
        caixaDeTexto.text = falas[indice];
    }

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null && gamepad.buttonSouth.wasPressedThisFrame) // X no PlayStation / A no Xbox
        {
            ProximoDialogo();
        }

        // Para quem estiver testando no PC sem controle:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProximoDialogo();
        }
    }

    private void ProximoDialogo()
    {
        indice++;
        if (indice < falas.Length)
        {
            caixaDeTexto.text = falas[indice];
        }
        else
        {
            SceneManager.LoadScene("Jogo"); // Vai para a cena do jogo
        }
    }
}
