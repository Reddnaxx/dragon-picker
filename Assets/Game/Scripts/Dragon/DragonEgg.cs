using System;
using UnityEngine;

namespace Game.Scripts.Dragon
{
    public class DragonEgg : MonoBehaviour
    {
        [SerializeField] private float minHeight = -30f;

        [SerializeField] private GameObject dragonEggModel;
        [SerializeField] private ParticleSystem hitParticles;

        private GameEntryPoint _entryPoint;

        private void Awake()
        {
            _entryPoint = FindFirstObjectByType<GameEntryPoint>();
        }

        private void OnTriggerEnter(Collider other)
        {
            dragonEggModel.SetActive(false);
            hitParticles.Play();
        }

        private void Update()
        {
            if (transform.position.y < minHeight)
            {
                Destroy(gameObject);

                _entryPoint.OnDragonEggDestroyed();
            }
        }
    }
}