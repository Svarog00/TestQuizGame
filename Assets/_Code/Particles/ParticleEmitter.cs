using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Particles
{
    public class ParticleEmitter : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem.Stop();
        }

        private void OnParticleSystemStopped()
        {
            _particleSystem.time = 0;
        }

        public void PlayParticles(Vector3 position)
        {
            position = new Vector3(position.x, position.y, position.z - 10);
            transform.position = position;
            _particleSystem.Play();
        }
    }
}