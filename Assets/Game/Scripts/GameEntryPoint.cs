using System.Collections.Generic;
using Game.Scripts.Dragon;
using Game.Scripts.Shield;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private EnergyShieldPreferences energyShieldPreferences;

        private Stack<GameObject> _energyShields = new();

        private InputHandler _inputHandler;

        private void Awake()
        {
            _inputHandler = new InputHandler();
        }

        private void Start()
        {
            SpawnShields();
        }

        public void OnDragonEggDestroyed()
        {
            var eggs = FindObjectsByType<DragonEgg>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (var egg in eggs)
            {
                Destroy(egg.gameObject);
            }
            
            Destroy(_energyShields.Pop());

            if (_energyShields.Count == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void SpawnShields()
        {
            for (var i = 1; i <= energyShieldPreferences.amount; i++)
            {
                SpawnShield(i * energyShieldPreferences.radius);
            }
        }

        private void SpawnShield(float scale)
        {
            var position = new Vector3(0, energyShieldPreferences.bottomY, 0);
            var obj = Instantiate(energyShieldPreferences.prefab, position, Quaternion.identity);
            obj.transform.localScale = Vector3.one * scale;

            _energyShields.Push(obj);
        }
    }
}