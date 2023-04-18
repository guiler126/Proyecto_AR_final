
using UnityEngine;

public class Movimientosencillo : MonoBehaviour
{
    [Header("Character Variables")]
    public float speed;
    public Transform respawn;
    
    private float horizontalInput;
    private float verticalInput;

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.back * (speed * verticalInput * Time.deltaTime));
        transform.Translate(Vector3.left * (speed * horizontalInput * Time.deltaTime));
        
    }
}
