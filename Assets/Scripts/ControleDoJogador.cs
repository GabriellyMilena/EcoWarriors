using UnityEngine; // Biblioteca principal do Unity.

public class ControleDoJogador : MonoBehaviour // Classe que controla o jogador (nave).
{
    [Header("Configurações de Cor")]
    public Color corAtual = Color.white; // Cor inicial do laser

    [Header("Componentes Principais")]
    public Rigidbody2D oRigidbody2D;
    public GameObject laserDoJogador; // Prefab do laser
    public Transform localDeDisparoUnico; // Posição de disparo

    [Header("Configurações de Jogo")]
    public bool temLaserDuplo = false;
    public float velocidadeDaNave = 5f;
    public bool jogadorVivo = true;

    private Vector2 teclasApertadas; // Direção de movimento

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

    // ✅ Controle de troca de cor via teclado ou controle
    private void TrocarCor()
    {
        // Troca de cor com teclado (1, 2, 3)
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
            corAtual = Color.yellow; // Alterado de azul para amarelo
            Debug.Log("Cor do laser alterada para: Amarelo");
        }

        // Troca de cor via joystick (A, B, X)
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
            corAtual = Color.yellow; // Alterado de azul para amarelo
            Debug.Log("Cor do laser alterada via controle: Amarelo");
        }
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instancia o laser
            GameObject novoLaser = Instantiate(laserDoJogador, localDeDisparoUnico.position, localDeDisparoUnico.rotation);

            // Aplica a cor atual no laser
            LaserDoJogador scriptLaser = novoLaser.GetComponent<LaserDoJogador>();
            if (scriptLaser != null)
            {
                scriptLaser.DefinirCor(corAtual);
            }

            // Som do disparo (mantido)
            if (EfeitosSonoros.instancia != null && EfeitosSonoros.instancia.somDoLaser != null)
            {
                EfeitosSonoros.instancia.somDoLaser.Play();
            }
        }
    }
}
