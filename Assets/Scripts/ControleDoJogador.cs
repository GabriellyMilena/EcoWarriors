using UnityEngine; // Biblioteca principal do Unity. 

 

public class ControleDoJogador : MonoBehaviour // Classe que controla o jogador (nave). 

{ 

    public Rigidbody2D oRigidbody2D;  

    // Componente de física 2D usado para movimentar a nave de forma suave. 

 
    public GameObject laserDoJogador; // Prefab do laser que será disparado. 

    public Transform localDeDisparoUnico; // Local onde o laser será instanciado (na ponta da nave, por exemplo). 

    public bool temLaserDuplo = false; // Variável para ativar/desativar o modo de disparo duplo. 

    public float velocidadeDaNave; // Define a velocidade de movimento da nave. 


    public bool jogadorVivo = true; // Controla se o jogador ainda está vivo (quando false, desativa o controle). 

 

    private Vector2 teclasApertadas; // Guarda a direção das teclas pressionadas. 

 

    void Update() // Chamado a cada frame. 

    { 

        if (!jogadorVivo) return; // Se o jogador estiver "morto", não executa nada. 

 

        MovimentarJogador(); // Controla o movimento. 

        Atirar(); // Controla o disparo. 

    } 

 

    private void MovimentarJogador() 

    { 

        // Pega as teclas de movimento (setas ou WASD). 

        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 

 

        // Move a nave de acordo com a direção das teclas, normalizando a velocidade. 

        oRigidbody2D.linearVelocity = teclasApertadas.normalized * velocidadeDaNave; 

    } 

 

    private void Atirar() 

    { 

        // Se o jogador apertar o botão de disparo (padrão: Ctrl esquerdo, mouse esquerdo ou botão "X" no joystick). 

        if (Input.GetButtonDown("Fire1")) 

        { 

            // Caso NÃO tenha o disparo duplo, instancia apenas 1 laser. 

            if (!temLaserDuplo) 

            { 

                Instantiate(laserDoJogador, localDeDisparoUnico.position, localDeDisparoUnico.rotation); 

            } 

 

            // Se o gerenciador de efeitos sonoros existir e tiver som de laser, toca o áudio. 

            if (EfeitosSonoros.instancia != null && EfeitosSonoros.instancia.somDoLaser != null) 

            { 

                EfeitosSonoros.instancia.somDoLaser.Play(); 

            } 

        } 

    } 

} 