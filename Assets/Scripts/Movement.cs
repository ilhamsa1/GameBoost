using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;

    AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
      void Update()
    {
        ProcessTrust();
        ProcessRotation();
    }

    void ProcessTrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // rb.AddRelativeForce(0, 1, 0);
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!m_MyAudioSource.isPlaying)
            {
                m_MyAudioSource.Play();
            }
        }
        else
        {
            m_MyAudioSource.Stop();
        }
    }

    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
           ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrames)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrames * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
