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
        
        private void Start()
        {
            _inputHandler = InputHandler.Instance;
            _camera = Camera.main;
            
            _inputHandler.OnMouseMove += Move;
            
            _scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
            _scoreText.text = "Score: 0";
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
                _scoreText.text = $"Score: {score}";
            }
        }
    }
}