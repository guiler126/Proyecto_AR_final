using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider;
    public float minSensitivity = 1f;
    public float maxSensitivity = 10f;

    public Camera playerCamera;
    public float baseRotationSpeed = 2f;
    public float sensitivityMultiplier = 1f;
    public float verticalRotationSpeedMultiplier = 1f;

    private void Start()
    {
        // Recupera el valor guardado de la sensibilidad del mouse utilizando PlayerPrefs
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 5f);
        sensitivitySlider.value = savedSensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);

        ApplyMouseSensitivity(savedSensitivity);
    }

    private void OnSensitivityChanged(float value)
    {
        float sensitivity = Mathf.Lerp(minSensitivity, maxSensitivity, value);
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();
        ApplyMouseSensitivity(sensitivity);
    }

    private void ApplyMouseSensitivity(float sensitivity)
    {
        float rotationSpeed = baseRotationSpeed * sensitivity * sensitivityMultiplier;
        float verticalRotationSpeed = rotationSpeed * verticalRotationSpeedMultiplier;

        // Aplica la sensibilidad al movimiento del mouse horizontal
        playerCamera.transform.Rotate(0f, Input.GetAxis("Mouse X") * rotationSpeed, 0f);

        // Aplica la sensibilidad al movimiento del mouse vertical
        playerCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * verticalRotationSpeed, 0f, 0f);

        // Ajusta la sensibilidad del mouse en la UI
        UnityEngine.EventSystems.EventSystem.current.pixelDragThreshold = Mathf.RoundToInt(sensitivity);
    }
}
