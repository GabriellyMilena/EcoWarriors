using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody2D oRigidbody2D;

    [Header("Disparo")]
    public GameObject laserDoJogador;
    public Transform localDeDisparoUnico;
    public bool temLaserDuplo = false;

    [Header("Movimento")]
    public float velocidadeDaNave;

    [Header("Status")]
    public bool jogadorVivo = true;

    private Vector2 teclasApertadas;

    void Update()
    {
        if (!jogadorVivo) return;

        MovimentarJogador();
        Atirar();
    }

    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.linearVelocity = teclasApertadas.normalized * velocidadeDaNave;
    }

    private void Atirar()
    {
        // Fire1 está mapeado por padrão para:
        // - Teclado: Ctrl esquerdo / mouse esquerdo
        // - Xbox: A
        // - PlayStation: X (cruz)
        if (Input.GetButtonDown("Fire1"))
        {
            if (!temLaserDuplo)
            {
                Instantiate(laserDoJogador, localDeDisparoUnico.position, localDeDisparoUnico.rotation);
            }

            if (EfeitosSonoros.instancia != null && EfeitosSonoros.instancia.somDoLaser != null)
            {
                EfeitosSonoros.instancia.somDoLaser.Play();
            }
        }
    }
}
