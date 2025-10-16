using UnityEngine;

public class ControleDoJogador : MonoBehaviour 
{
    public Color corAtual = Color.white;
    public Rigidbody2D oRigidbody2D;
    public GameObject laserDoJogador;
    public Transform localDeDisparoUnico;
    public bool temLaserDuplo = false;
    public float velocidadeDaNave = 5f;
    public bool jogadorVivo = true;

    private Vector2 teclasApertadas;

    void Update()
    {
        if (!jogadorVivo) return;

        MovimentarJogador();
        TrocarCor();
        Atirar();
    }
    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.linearVelocity = teclasApertadas.normalized * velocidadeDaNave;
    }
    private void TrocarCor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            corAtual = Color.red;
            Debug.Log("Cor do laser alterada para: Vermelho");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            corAtual = Color.green;
            Debug.Log("Cor do laser alterada para: Verde");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            corAtual = Color.yellow;
            Debug.Log("Cor do laser alterada para: Amarelo");
        }

        if (Input.GetButtonDown("Fire2")) // A
        {
            corAtual = Color.red;
            Debug.Log("Cor do laser alterada via controle: Vermelho");
        }
        if (Input.GetButtonDown("Fire3")) // B
        {
            corAtual = Color.green;
            Debug.Log("Cor do laser alterada via controle: Verde");
        }
        if (Input.GetButtonDown("Jump")) // X
        {
            corAtual = Color.yellow;
            Debug.Log("Cor do laser alterada via controle: Amarelo");
        }
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject novoLaser = Instantiate(laserDoJogador, localDeDisparoUnico.position, localDeDisparoUnico.rotation);
            LaserDoJogador scriptLaser = novoLaser.GetComponent<LaserDoJogador>();
            if (scriptLaser != null)
            {
                scriptLaser.DefinirCor(corAtual);
            }
            if (EfeitosSonoros.instancia != null && EfeitosSonoros.instancia.somDoLaser != null)
            {
                EfeitosSonoros.instancia.somDoLaser.Play();
            }
        }
    }
}
