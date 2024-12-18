using System.Linq;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Shield
{
    public class EnergyShield : MonoBehaviour
    {
        private InputHandler _inputHandler;

        private Camera _camera;
        private TMP_Text _scoreText;
        private TMP_Text _bestScoreText;
        
        private AudioSource _audioSource;

        private int _bestScore;
        
        private void Start()
        {
            _inputHandler = InputHandler.Instance;
            _camera = Camera.main;
            _audioSource = GetComponent<AudioSource>();
            
            _inputHandler.OnMouseMove += Move;
            
            _scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
            _scoreText.text = "Score: 0";
            _bestScore = PlayerPrefs.GetInt("BestScore", 0);
            _bestScoreText = GameObject.Find("BestScore").GetComponent<TMP_Text>();
            _bestScoreText.text = $"Best Score: {_bestScore}";
        }

        private void OnDestroy()
        {
            _inputHandler.OnMouseMove -= Move;
        }

        private void Move(Vector2 mousePosition)
        {
            var worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(worldPoint.x, transform.position.y, transform.position.z);
        }

        private void OnCollisionEnter(Collision other)
        {
            var obj = other.gameObject;

            if (obj.CompareTag("Dragon Egg"))
            {
                Destroy(obj);
                
                var score = int.Parse(_scoreText.text.Split(' ').Last());
                score += 1;

                if (score > _bestScore)
                {
                    _bestScore = score;
                    PlayerPrefs.SetInt("BestScore", _bestScore);
                }
                
                _scoreText.text = $"Score: {score}";
                _audioSource.Play();
            }
        }
    }
}