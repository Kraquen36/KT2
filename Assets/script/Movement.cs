using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vitesseDeplacement = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical);
        Vector3 nouvelleVitesse = deplacement * vitesseDeplacement;

        rb.velocity = nouvelleVitesse;
    }
}