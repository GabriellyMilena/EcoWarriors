using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;

    public GameObject laserDoJogador;

    public Transform localDeDisparoUnico;

    public float velocidadeDaNave;

    public bool temLaserDuplo;

    private Vector2 teclasApertadas;

    void Start()
    {
        temLaserDuplo = false;
    }


    void Update()
    {
        MovimentarJogador();
        Atirar();
    }
    private void MovimentarJogador()
    {
        teclasApertadas = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.linearVelocity = teclasApertadas.normalized * velocidadeDaNave;


    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (temLaserDuplo == false) {
                Instantiate(laserDoJogador, localDeDisparoUnico.position, localDeDisparoUnico.rotation);
            }
        }
    }
}
