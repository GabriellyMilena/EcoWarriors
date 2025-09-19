using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{

    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;

    public bool temEscudo;


    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        temEscudo = false;
    }


    void Update()
    {

    }

    public void ReceberDano(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
