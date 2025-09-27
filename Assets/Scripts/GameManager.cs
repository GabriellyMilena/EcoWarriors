using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public AudioSource musicaDeFundo;
    public AudioSource musicaDeGameOver;

    public Text textoDePontuacao;
    public int PontuacaoAtual;

    public GameObject painelDeGameOver;
    public Text textoDeGameOver;      
    public Text textoDePontuacaoFinal;
    public Text textoDeHighScore;

    public GameObject jogador; // Referência ao Player

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        musicaDeFundo.Play();

        textoDePontuacao.text = "PONTUAÇÃO: " + PontuacaoAtual;
    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        PontuacaoAtual += pontosParaGanhar;
        textoDePontuacao.text = "PONTUAÇÃO: " + PontuacaoAtual;
    }

    public void GameOver()
    {
        // Pausa
        Time.timeScale = 0;

        // Música
        musicaDeFundo.Stop();
        musicaDeGameOver.Play();

        // Desativa player
        if (jogador != null)
            jogador.SetActive(false);

        // Texto fixo do título
        if (textoDeGameOver != null)
            textoDeGameOver.text = "GAME OVER";

        // Pontuação final
        if (textoDePontuacaoFinal != null)
            textoDePontuacaoFinal.text = "PONTUAÇÃO: " + PontuacaoAtual;

        // HighScore
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (PontuacaoAtual > highScore)
        {
            highScore = PontuacaoAtual;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (textoDeHighScore != null)
            textoDeHighScore.text = "MELHOR PONTUAÇÃO: " + highScore;

        // Ativa painel
        if (painelDeGameOver != null)
            painelDeGameOver.SetActive(true);
    }  
}
