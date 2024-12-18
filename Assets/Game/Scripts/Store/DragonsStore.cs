using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Game.Scripts.Store
{
    public class DragonsStore : MonoBehaviour
    {
        [SerializeField] private List<DragonStoreItem> dragonStoreItems;
        [SerializeField] private TMP_Text coinsText;

        private int _coins;
        private InputHandler _inputHandler;

        private string _boughtDragons;

        private void Awake()
        {
            _inputHandler = new InputHandler();
            _coins = PlayerPrefs.GetInt("Coins", 0);
            _boughtDragons = PlayerPrefs.GetString("BoughtDragons", string.Empty);

            if (_boughtDragons.Length == 0)
            {
                PlayerPrefs.SetString("BoughtDragons", "0");
                _boughtDragons = "0";
            }

            _inputHandler.OnToMainMenu += GoToMainMenu;
            
            Debug.Log(_boughtDragons);
        }

        private void Start()
        {
            UpdateCoins();

            foreach (var item in dragonStoreItems)
            {
                item.OnDragonSelect += UpdateDragons;
                item.OnDragonBuy += BuyDragon;
            }
        }

        private void BuyDragon(DragonItem item)
        {
            if (_coins < item.price) return;

            _coins -= item.price;
            UpdateCoins();

            _boughtDragons += $",{item.id}";
            PlayerPrefs.SetString("BoughtDragons", _boughtDragons);

            UpdateDragons();
        }

        private void UpdateDragons()
        {
            foreach (var item in dragonStoreItems)
            {
                item.UpdateState();
            }
        }

        private void UpdateCoins()
        {
            PlayerPrefs.SetInt("Coins", _coins);
            coinsText.text = $"Coins: {_coins}";
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        [ProButton]
        public void ClearBoughtDragons()
        {
            PlayerPrefs.DeleteKey("BoughtDragons");
        }

        private void OnDestroy()
        {
            _inputHandler.OnToMainMenu -= GoToMainMenu;

            foreach (var item in dragonStoreItems)
            {
                item.OnDragonSelect -= UpdateDragons;
                item.OnDragonBuy -= BuyDragon;
            }
        }
    }
}