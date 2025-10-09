using UnityEngine;
using VolumetricLines;


public class LaserDoJogador : MonoBehaviour
{
    [Header("Propriedades de Movimento")]
    public float velocidadeDoLaser = 10f;

    [Header("Propriedades de Combate")]
    public int danoCausado = 1;
    public GameObject impactoDoLaser;

    [Header("Componentes Internos")]
    private SpriteRenderer rend; 
    private VolumetricLineBehavior volumetricLine; // 👈 compatibilidade com seu prefab

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        volumetricLine = GetComponent<VolumetricLineBehavior>(); // 👈 tenta encontrar o componente do laser 3D

        if (rend == null && volumetricLine == null)
        {
            Debug.LogWarning("⚠️ Nenhum componente visual encontrado (nem SpriteRenderer nem VolumetricLineBehavior).");
        }
    }

    void Update()
    {
        // Movimento contínuo do laser
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);

        // Destruição automática fora da tela
        if (transform.position.y > Camera.main.orthographicSize * 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LixoEspacial"))
        {
            var lixo = other.GetComponent<LixoEspacial>();
            if (lixo != null)
            {
                lixo.MachucarLixo(danoCausado);
            }

            if (impactoDoLaser != null)
            {
                Instantiate(impactoDoLaser, transform.position, transform.rotation);
            }

            if (EfeitosSonoros.instancia?.somDeImpacto != null)
            {
                EfeitosSonoros.instancia.somDeImpacto.Play();
            }

            Destroy(gameObject);
        }
    }

    // ✅ Compatível com SpriteRenderer e VolumetricLineBehavior
    public void DefinirCor(Color cor)
    {
        if (rend != null && rend.material != null)
        {
            rend.material.color = cor;
        }

        if (volumetricLine != null)
        {
            volumetricLine.LineColor = cor; // 👈 o campo correto para alterar cor no laser volumétrico
        }

        Debug.Log("Cor do laser aplicada visualmente: " + cor);
    }
}
