using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Dragon
{
    public class MenuDragon : MonoBehaviour
    {
        [SerializeField] private List<GameObject> dragonsPrefab;

        private int _selectedDragon;
        
        private void Start()
        {
            _selectedDragon = PlayerPrefs.GetInt("SelectedDragon");
            
            Instantiate(dragonsPrefab[_selectedDragon], transform);
        }
    }
}