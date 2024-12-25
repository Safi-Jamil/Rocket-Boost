using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb;
    AudioSource audioSource;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Correctly initialize the AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on this GameObject!");
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);

            if (audioSource != null)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
        else
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        float rotationInput = rotation.ReadValue<float>();
        Debug.Log("This is our rotation value: " + rotationInput);

        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }
    }

    private void ApplyRotation(float rotationStrength)
    {
        transform.Rotate(Vector3.forward * rotationStrength * Time.fixedDeltaTime);
    }
}
