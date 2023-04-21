using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Camera mainCamera;
    public GameObject panel_youLose;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        /**if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Lanzamos un rayo desde la posición de la camera a donde se encuentre el mouse
            //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Si el rayo impacta con algo, diremos al jugador que tiene que ir a esa posición
            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }*/

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Me has tocado");
            panel_youLose.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
