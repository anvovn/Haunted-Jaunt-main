using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    [SerializeField] float dashSpeed = 1f;
    private float speedMultiplier;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    private bool isDashing;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        isDashing = false;
        speedMultiplier = 1f;
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isDashing)
            {
                StartCoroutine(Dash());
            }
        }
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * (speedMultiplier));
        m_Rigidbody.MoveRotation (m_Rotation);
    }
    IEnumerator Dash()
    {
        isDashing = true;
        float dashDuration = 0.5f; // Duration of the dash in seconds
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            speedMultiplier = 1+(dashSpeed* (Mathf.Pow(1 - elapsedTime/dashDuration, 5))); //LINEAR INTERPOLATION
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        speedMultiplier = 1f;
        isDashing = false;
        
    }
}