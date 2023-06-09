using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Main_Menu_Sergio");
        Time.timeScale = 1.0f;
    }
}
