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
                other.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            Destroy(gameObject);
        }
    }
}



