using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemEscudo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemEscudo)
            {
                // Ativa escudo no jogador
                other.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            // Destroi o item após coletar
            Destroy(gameObject);
        }
    }
}
