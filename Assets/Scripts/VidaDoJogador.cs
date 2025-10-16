using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{

    public Slider barraDeVida;
    public Slider barraDeEscudo;
    public GameObject escudoDoJogador;
    public int vidaMaximaDoEscudo;
    private int vidaAtualDoEscudo;
    private bool temEscudo = false;
    public int vidaMaximaDoJogador;
    private int vidaAtualDoJogador;

    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        barraDeVida.maxValue = vidaMaximaDoJogador;
        barraDeVida.value = vidaAtualDoJogador;
        barraDeEscudo.maxValue = vidaMaximaDoEscudo;
        vidaAtualDoEscudo = 0;
        barraDeEscudo.value = 0;
        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        barraDeEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void ReceberDano(int dano)
    {
        if (temEscudo)
        {
            vidaAtualDoEscudo -= dano;
            barraDeEscudo.value = vidaAtualDoEscudo;

            if (vidaAtualDoEscudo <= 0)
            {
                temEscudo = false;
                escudoDoJogador.SetActive(false);
                vidaAtualDoEscudo = 0;
                barraDeEscudo.value = vidaAtualDoEscudo;
            }
        }
        else
        {
            vidaAtualDoJogador -= dano;
            barraDeVida.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                vidaAtualDoJogador = 0;
                barraDeVida.value = 0;

                ControleDoJogador jogador = FindObjectOfType<ControleDoJogador>();
                if (jogador != null) jogador.jogadorVivo = false;

                if (GameManager.instancia != null) GameManager.instancia.GameOver();

                Debug.Log("Game Over");
            }
        }
    }
}

    