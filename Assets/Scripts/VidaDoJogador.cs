using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{

    public Slider barraDeVida;

    public Slider barraDeEscudo;

    public GameObject escudoDoJogador;


    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;

    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;

    public bool temEscudo;


    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        temEscudo = false;

        barraDeVida.maxValue = vidaMaximaDoJogador;
        barraDeVida.value = vidaAtualDoJogador;

        barraDeEscudo.maxValue = vidaMaximaDoEscudo;
        barraDeEscudo.value = vidaAtualDoEscudo;

        //barraDeEscudo.gameObject.SetActive(false);

        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }


    void Update()
    {

    }


    public void AtivarEscudo()
    {

        //barraDeEscudo.gameObject.SetActive(true);

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void ReceberDano(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVida.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");
            }
        }else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            barraDeEscudo.value = vidaAtualDoEscudo;
            if (vidaAtualDoEscudo <= 0)
            {
                temEscudo = false;
                escudoDoJogador.SetActive(false);

                //barraDeEscudo.gameObject.SetActive(false);


            }
        }
    }
}
