using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeDoCenario = 0.5f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogError("Cenario precisa de Renderer (Quad, Plane ou Mesh com material)");
            enabled = false;
        }
    }
    void Update()
    {
        MovimentarCenario();
    }
    private void MovimentarCenario()
    {
        float deslocamento = velocidadeDoCenario * Time.time; 

        float offsetX = Mathf.Repeat(deslocamento, 1f);

        rend.material.mainTextureOffset = new Vector2(offsetX, 0f);
    }
}
