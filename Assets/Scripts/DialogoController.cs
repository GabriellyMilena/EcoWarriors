using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DialogoController : MonoBehaviour
{
    public Text caixaDeTexto;

    private string[] falas = new string[]
    {
        "A Terra está em perigo: o lixo espacial se acumula em órbita!",
        "Satélites danificados e toneladas de detritos ameaçam missões e a vida no planeta.",
        "Para salvar o futuro, foi criada a Nave Ecológica, capaz de reciclar e destruir os detritos espaciais.",
        "Sua missão é simples: proteger a Terra e restaurar o equilíbrio ambiental.",
        "Use o analógico esquerdo para mover a nave.",
        "Pressione os botões X, Y ou B para trocar a cor do laser (verde, amarelo e vermelho).",
        "Assim que escolher a cor, pressione o botão A para atirar.",
        "Recolha os itens de escudo quando aparecerem para se proteger dos impactos.",
        "Cuidado: ao colidir com o lixo espacial, você perderá vida.",
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
        if (gamepad != null && gamepad.buttonSouth.wasPressedThisFrame)
        {
            ProximoDialogo();
        }
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
            SceneManager.LoadScene("Jogo");
        }
    }
}
