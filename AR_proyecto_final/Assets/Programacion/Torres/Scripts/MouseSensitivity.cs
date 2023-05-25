using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    [SerializeField]
    private Slider sensitivitySlider;

    [SerializeField, Range(1f, 10f)]
    private float minSensitivity = 1f;

    [SerializeField, Range(1f, 10f)]
    private float maxSensitivity = 10f;

    private const string SensitivityKey = "MouseSensitivity";

    private void Start()
    {
        float savedSensitivity = PlayerPrefs.GetFloat(SensitivityKey, 5f);
        sensitivitySlider.value = savedSensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    private void OnSensitivityChanged(float value)
    {
        float sensitivity = Mathf.Lerp(minSensitivity, maxSensitivity, value);
        PlayerPrefs.SetFloat(SensitivityKey, sensitivity);
        PlayerPrefs.Save();
        ApplyMouseSensitivity(sensitivity);
    }

    private void ApplyMouseSensitivity(float sensitivity)
    {
        // Multiplica el valor de sensibilidad por un factor adecuado seg�n tus necesidades
        // y apl�calo al control del rat�n
        float mouseSensitivity = sensitivity * 2f; // Puedes ajustar el factor multiplicador seg�n tus preferencias

        // Aplica la sensibilidad del rat�n a trav�s de Input.GetAxisRaw("Mouse X") y Input.GetAxisRaw("Mouse Y")
        // Puedes utilizar estos valores para controlar la rotaci�n o movimiento de tu personaje

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        // A continuaci�n, puedes utilizar los valores de mouseX y mouseY seg�n tus necesidades en tu l�gica de juego

        // Ejemplo: Rotaci�n del personaje en el eje Y (horizontal)
        //transform.Rotate(Vector3.up, mouseX);

        // Ejemplo: Rotaci�n de la c�mara en el eje X (vertical)
        // (Aseg�rate de tener una c�mara o un objeto que siga al personaje)
        //Camera.main.transform.Rotate(Vector3.right, -mouseY);
    }

}
