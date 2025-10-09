using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeDoCenario = 0.5f; // velocidade do deslocamento
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogError("⚠️ Cenario precisa de Renderer (Quad, Plane ou Mesh com material)");
            enabled = false;
        }
    }

    void Update()
    {
        MovimentarCenario();
    }

    private void MovimentarCenario()
    {
        // Calcula o deslocamento com base em Time.deltaTime para movimento contínuo
        float deslocamento = velocidadeDoCenario * Time.time; 

        // Mantém o valor entre 0 e 1 para repetir
        float offsetX = Mathf.Repeat(deslocamento, 1f);

        // Aplica o deslocamento no material
        rend.material.mainTextureOffset = new Vector2(offsetX, 0f);
    }
}
