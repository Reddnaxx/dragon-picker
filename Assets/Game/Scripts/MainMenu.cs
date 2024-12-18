using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text bestScoreText;

        private void Start()
        {
            var bestScore = PlayerPrefs.GetInt("BestScore", 0);
            bestScoreText.text = $"Best Score: {bestScore}";
            
            PlayerPrefs.SetInt("Coins", 1000);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void OpenStore()
        {
            SceneManager.LoadScene("Store");
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
