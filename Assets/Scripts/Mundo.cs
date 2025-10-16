using UnityEngine;

public class Mundo : MonoBehaviour
{
    [Tooltip("Velocidade de rotação da Terra (graus por segundo)")]
    public float velocidadeRotacao = 5f;

    [Tooltip("Tag do jogador (normalmente 'Player')")]
    public string tagDoJogador = "Player";

    private void Update()
    {
        transform.Rotate(0, 0, velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("LixoEspacial")) return;

        LixoEspacial lixo = other.GetComponent<LixoEspacial>();
        int dano = (lixo != null) ? lixo.danoCausado : 1;
        GameObject jogador = GameObject.FindGameObjectWithTag(tagDoJogador);
        if (jogador != null)
        {
            VidaDoJogador vida = jogador.GetComponent<VidaDoJogador>();
            if (vida != null)
            {
                vida.ReceberDano(dano);
                Debug.Log($"Terra: jogador recebeu {dano} de dano.");
            }
        }
        else
        {
            Debug.LogWarning("Terra: jogador não encontrado com a tag '" + tagDoJogador + "'.");
        }
        if (lixo != null && lixo.impactoDoLixo != null)
        {
            Instantiate(lixo.impactoDoLixo, other.transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
    }
}


