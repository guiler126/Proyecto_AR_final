using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que quieres cambiar

    public void CambiaEsc()
    {
        SceneManager.LoadScene(sceneName); // Cambiar a la escena especificada
    }
}
