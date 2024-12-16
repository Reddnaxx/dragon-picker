using UnityEngine;

namespace Game.Scripts.Dragon
{
    public class DragonEgg: MonoBehaviour
    {
        [SerializeField] private float minHeight = -30f;
        
        [SerializeField] private GameObject dragonEggModel;
        [SerializeField] private ParticleSystem hitParticles;

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
            }
        }
    }
}