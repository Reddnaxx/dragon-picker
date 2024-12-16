using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Game.Scripts
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        
        private bool _paused;
        private InputHandler _inputHandler;

        private void Start()
        {
            _inputHandler = InputHandler.Instance;

            _inputHandler.OnPause += TogglePause;
            _inputHandler.OnToMainMenu += ToMainMenu;
        }

        private void TogglePause()
        {
            _paused = !_paused;
            
            Time.timeScale = _paused ? 0 : 1;
            panel.SetActive(_paused);
        }

        private void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
