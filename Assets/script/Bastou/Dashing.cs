using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public float vitesseDash = 10f; // Vitesse du dash
    public float dureeDash = 0.2f; // Durée du dash
    private Rigidbody rb;
    private bool isDashing = false;

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

        if (Input.GetKeyDown(KeyCode.F) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if (!isDashing)
        {
            rb.velocity = nouvelleVitesse;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        float startTime = Time.time;
        Vector3 direction = rb.velocity.normalized; // Direction du dash

        while (Time.time < startTime + dureeDash)
        {
            rb.velocity = direction * vitesseDash;
            yield return null;
        }

        isDashing = false;
    }
}
