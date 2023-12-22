using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpider : MonoBehaviour
{
    public float velocidad = 1f;  // Velocidad de movimiento
    private Animator animator;    // Referencia al componente Animator

    void Start()
    {
        // Obtener la referencia al componente Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector3 movimiento = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Presiona la tecla "1" para la animación Attack
        {
            //animator.SetTrigger("Attack");
            animator.SetBool("Attack",true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Presiona la tecla "1" para la animación Attack
        {
            //animator.SetTrigger("Attack");
            animator.SetBool("Die",true);
        }

        // Si hay entrada de teclado, actualizar la animación y mover el personaje
        if (movimiento.magnitude >= 0.1f)
        {
            // Calcular la rotación hacia la dirección de movimiento
            float targetAngle = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidad, 0.1f);

            // Aplicar la rotación al personaje
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mover el personaje
            transform.Translate(movimiento * velocidad, Space.World);

            // Actualizar la animación de caminar
            animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            // Si no hay entrada, detener la animación de caminar
            animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }
    }
}



