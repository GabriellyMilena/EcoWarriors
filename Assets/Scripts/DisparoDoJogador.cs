using UnityEngine;

public class DisparoDoJogador : MonoBehaviour
{
    public GameObject prefabLaser;
    private Color corAtual = Color.white;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            corAtual = Color.green;
            Debug.Log("Cor atual: Verde");
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            corAtual = Color.blue;
            Debug.Log("Cor atual: Azul");
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton2)) {
            corAtual = Color.red;
            Debug.Log("Cor atual: Vermelho");
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
            corAtual = Color.yellow;
            Debug.Log("Cor atual: Amarelo");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.Space))
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
            else
                Debug.LogWarning("⚠️ O prefab não contém o script LaserDoJogador!");
        }
    }
}


