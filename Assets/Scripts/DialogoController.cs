using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoController : MonoBehaviour
{
    public Text caixaDeTexto;
    private string[] falas = new string[]
    {
        "A Terra enfrenta um grave perigo: o lixo espacial!",
        "Satélites quebrados e toneladas de sucata ameaçam missões e a vida no planeta.",
        "Para salvar o futuro, criamos a Nave Ecológica, capaz de reciclar e destruir os detritos em órbita.",
        "Sua missão é clara: proteger a Terra e restaurar o equilíbrio ambiental.",
        "Use WASD para se mover e o mouse para atirar.",
        "Além disso, a nave possui um sistema inteligente que permite mudar sua cor. Para ativá-lo, aperte C.",
        "Além disso, a nave possui um escudo. Basta pegar o item de escudo que aparece de vez em quando.",
        "Se você colidir com o lixo espacial, perderá vida. Cuidado!",
        "Boa sorte, herói!"
    };


    private int indice = 0;

    void Start()
    {
        caixaDeTexto.text = falas[indice];
    }

    public void ProximoDialogo()
    {
        indice++;
        if (indice < falas.Length)
        {
            caixaDeTexto.text = falas[indice];
        }
        else
        {
            // quando terminar o diálogo, abre a cena de jogo
            SceneManager.LoadScene("Jogo");
        }
    }
}
