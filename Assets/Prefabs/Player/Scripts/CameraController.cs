using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    public Transform target; // El objetivo que la cámara seguirá
    public float smoothSpeed = 0.125f; // Velocidad de la camara
    public Vector3 offset; // Desplazamiento de la cámara respecto al objetivo
    #endregion

    #region Methods
    private void LateUpdate()
    {
        // Posición deseada de la cámara
        Vector3 posicionDeseada = target.position + offset;
        // Suavizar el movimiento de la cámara
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, smoothSpeed);
        transform.position = posicionSuavizada;
        //Mantener la cámara mirando al objetivo
        transform.LookAt(target);
    }
    #endregion
}
