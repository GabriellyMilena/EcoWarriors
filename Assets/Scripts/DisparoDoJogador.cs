using UnityEngine;

public class DisparoDoJogador : MonoBehaviour
{
    public GameObject prefabLaser;
    [HideInInspector]
    public Color corAtual = Color.white;

    void Update()
    {
        // Disparo com botão do controle ou espaço
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (prefabLaser == null)
            {
                Debug.LogWarning("⚠️ Prefab Laser não atribuído!");
                return;
            }

            GameObject laser = Instantiate(prefabLaser, transform.position, transform.rotation);
            var laserScript = laser.GetComponent<LaserDoJogador>();
            if (laserScript != null)
                laserScript.DefinirCor(corAtual);
        }
    }
}
