using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    [SerializeField]
    private AudioSource explosionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find Particle System of Capsule's child
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckAndAct(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        CheckAndAct(other.gameObject);
    }

    void CheckAndAct(GameObject obj)
    {
        if (obj.CompareTag("Bomb"))
        {
            if (explosionSound != null)
            {
                explosionSound.Play();
            }

            if (_particleSystem != null)
            {
                _particleSystem.Play();
            }
            Destroy(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
