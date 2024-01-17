using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // O objeto que a c�mera seguir�
    public Vector3 offset;    // A posi��o relativa da c�mera em rela��o ao objeto

    void Update()
    {
        if (target != null)
        {
            
            // Mant�m a rota��o da c�mera igual � rota��o inicial
            transform.rotation = Quaternion.identity;
        }
    }
}


