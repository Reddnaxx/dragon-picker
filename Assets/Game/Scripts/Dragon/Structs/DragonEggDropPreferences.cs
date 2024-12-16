using System;
using UnityEngine;

namespace Game.Scripts.Dragon.Structs
{
    [Serializable]
    public struct DragonEggDropPreferences
    {
        public GameObject prefab;
        public float dropCooldown;
        public Vector3 dropOffset;
    }
}