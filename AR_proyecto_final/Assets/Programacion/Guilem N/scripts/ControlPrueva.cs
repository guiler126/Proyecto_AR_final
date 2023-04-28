using System;

using UnityEngine;

public class ControlPrueva : MonoBehaviour
{
    [Header("--- Player Components ---")]
    [SerializeField] private CharacterController characterController;
    
    [Space]
    [Header("--- Player Attributes ---")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;

    // Private Attributes
    private Vector3 velocity;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private float xRot;
    
    
    // Update is called once per frame
    void Update()
    {
        // Capturamos los inputs del jugador y los almacenamos en las Variables de tipo Vector3 y Vector2
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        
        MovePlayer();

    }
    
    
    /// <summary>
    /// Método para mover al jugador hacia la dirección que esté pulsado con el teclado
    /// </summary>
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput);

        if (characterController.isGrounded)
        {
            velocity.y = -1f;
            
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }
        
        characterController.Move(moveVector * speed * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);

    }
    
  
}
