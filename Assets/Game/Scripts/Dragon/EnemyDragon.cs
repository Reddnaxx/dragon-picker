using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Dragon.Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Dragon
{
    public class EnemyDragon : MonoBehaviour
    {
        [SerializeField] private List<GameObject> modelsList = new();

        [SerializeField] private DragonPreferences preferences;
        [SerializeField] private DragonEggDropPreferences eggDropPreferences;

        private int _dragonModel;
        private bool _isAlive = true;

        private void Start()
        {
            _dragonModel = PlayerPrefs.GetInt("SelectedDragon", 0);
            Instantiate(modelsList[_dragonModel], transform);
            
            StartCoroutine(DropEgg());
        }

        private IEnumerator DropEgg()
        {
            while (_isAlive)
            {
                yield return new WaitForSeconds(eggDropPreferences.dropCooldown);
                CreateEgg();
            }
        }

        private void CreateEgg()
        {
            Instantiate(
                eggDropPreferences.prefab,
                transform.position + eggDropPreferences.dropOffset,
                Quaternion.identity
            );
        }

        private void Update()
        {
            var pos = transform.position;

            pos.x += preferences.speed * Time.deltaTime;

            transform.position = pos;

            if (pos.x < -preferences.leftRightDistance)
            {
                preferences.speed = Math.Abs(preferences.speed);
            }
            else if (pos.x > preferences.leftRightDistance)
            {
                preferences.speed = -Math.Abs(preferences.speed);
            }
        }

        private void FixedUpdate()
        {
            if (Random.value < preferences.chanceDirectionChange)
            {
                preferences.speed *= -1f;
            }
        }

        private void OnDestroy()
        {
            _isAlive = false;
            StopCoroutine(DropEgg());
        }
    }
}