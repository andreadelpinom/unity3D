using UnityEngine;

public class GarbageControllers : MonoBehaviour
{
   public string targetTag = "ItemGenerator"; // Etiqueta de los objetos generados

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tiene la etiqueta deseada
        if (other.CompareTag(targetTag))
        {
            // Desactiva o destruye el objeto
            other.gameObject.SetActive(false); // Usar pooling si es posible
            // Alternativa: Destroy(other.gameObject); // Si no usas pooling
        }
    }
}