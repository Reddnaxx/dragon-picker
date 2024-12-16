using System;
using Game.Scripts.EnergyShield;
using UnityEngine;

namespace Game.Scripts
{
    public class GameEntryPoint: MonoBehaviour
    {
        [SerializeField] private EnergyShieldPreferences energyShieldPreferences;

        private void Start()
        {
            SpawnShields();
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
        }
    }
}