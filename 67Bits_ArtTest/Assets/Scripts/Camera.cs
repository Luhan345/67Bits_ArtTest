using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // O objeto que a câmera seguirá
    public Vector3 offset;    // A posição relativa da câmera em relação ao objeto

    void Update()
    {
        if (target != null)
        {
            
            // Mantém a rotação da câmera igual à rotação inicial
            transform.rotation = Quaternion.identity;
        }
    }
}


