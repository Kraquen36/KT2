using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le transform du personnage que la caméra doit suivre
    public Vector3 offset; // L'offset entre la caméra et le personnage
    public float smoothSpeed = 0.125f; // La vitesse de transition de la caméra
    public float delayTime = 0.5f; // Le délai avant que la caméra commence à bouger

    private float startTime;

    void Start()
    {
        startTime = Time.time; // Enregistre le moment où le script est démarré
    }

    void LateUpdate()
    {
        if (target != null && Time.time - startTime > delayTime)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(target); // La caméra regarde toujours le personnage
        }
    }
}
