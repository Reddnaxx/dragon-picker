using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
