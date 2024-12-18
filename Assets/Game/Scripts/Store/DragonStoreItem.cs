using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Store
{
    [Serializable]
    public struct DragonItem
    {
        public int id;
        public int price;
    }
    
    public class DragonStoreItem : MonoBehaviour
    {
        public event Action OnDragonSelect;
        public event Action<DragonItem> OnDragonBuy;
        
        [SerializeField] private int id;

        [SerializeField] private GameObject dragonPrefab;
        [SerializeField] private string title;
        [SerializeField] private int price;

        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private Button buyButton;

        private List<string> _boughtDragons;
        private int _selectedDragon;
        private int _coins;

        private void Start()
        {
            Instantiate(dragonPrefab, transform);

            UpdateState();
        }

        public void UpdateState()
        {
            buyButton.onClick.RemoveAllListeners();
            
            _boughtDragons = PlayerPrefs.GetString("BoughtDragons", string.Empty).Split(",").ToList();
            _selectedDragon = PlayerPrefs.GetInt("SelectedDragon", 0);
            _coins = PlayerPrefs.GetInt("Coins", 0);
            
            if (_boughtDragons.Contains(id.ToString()))
            {
                buyButton.onClick.AddListener(SelectDragon);
                
                titleText.text = title;
                priceText.text = "Owned";
                buyButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
                
                buyButton.interactable = _selectedDragon != id;
            }
            else
            {
                buyButton.onClick.AddListener(BuyDragon);
                
                titleText.text = title;
                priceText.text = $"{price} Coins";

                buyButton.interactable = _coins >= price;
            }
        }

        public void SelectDragon()
        {
            _selectedDragon = id;
            
            PlayerPrefs.SetInt("SelectedDragon", _selectedDragon);
            UpdateState();
            
            OnDragonSelect?.Invoke();
        }

        public void BuyDragon()
        {
            OnDragonBuy?.Invoke(new DragonItem { id = id, price = price });
        }
    }
}