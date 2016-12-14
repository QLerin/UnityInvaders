using UnityEngine;
using System.Collections;

public class ParticlesAttractor : MonoBehaviour
{

    [SerializeField]
    private Transform _attractorTransform;

    public ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[5000];

    public void Start()
    {
    }

    public void LateUpdate()
    {
        _particleSystem.GetComponent<Transform>().Rotate(0, 0, 30 * Time.deltaTime);
        if (_particleSystem.isPlaying)
        {
            int length = _particleSystem.GetParticles(_particles);
            Vector3 attractorPosition = _attractorTransform.position;

            for (int i = 0; i < length; i++)
            {
                _particles[i].position = _particles[i].position + (new Vector3(0,0,0) - _particles[i].position) / (_particles[i].lifetime) * Time.deltaTime;
            }
            _particleSystem.SetParticles(_particles, length);
        }

    }
}