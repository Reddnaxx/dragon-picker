using System;
using UnityEngine;

namespace Game.Scripts.EnergyShield
{
    [Serializable]
    public struct EnergyShieldPreferences
    {
        public GameObject prefab;
        public int amount;
        public float bottomY;
        public float radius;
    }
}