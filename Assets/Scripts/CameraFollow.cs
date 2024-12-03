using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    // Referencia al objetivo que la cámara seguirá
    public Transform target;

    // Configuraciones de la cámara
    public float followSpeed = 5f;    // Velocidad con la que la cámara sigue al objetivo
    public Vector3 offset = new Vector3(0, 3, -5); // Offset de la cámara respecto al objetivo

    void Start()
    {
        // Verificación de seguridad
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo para que la cámara siga");
        }
    }

    void LateUpdate()
    {
        // Asegúrate de que el objetivo esté asignado
        if (target != null)
        {
            // Calcula la posición deseada basada en el objetivo y el offset
            Vector3 desiredPosition = target.position + offset;

            // Interpola suavemente la posición actual de la cámara hacia la deseada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);

            // Haz que la cámara mire hacia el objetivo
            transform.LookAt(target);
        }
    }
}
