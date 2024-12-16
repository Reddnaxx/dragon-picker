using System;
using UnityEngine;

namespace Game.Scripts
{
    public class InputHandler
    {
        public static InputHandler Instance;

        public event Action<Vector2> OnMouseMove;
        public event Action OnPause;
        public event Action OnToMainMenu;
        
        private readonly InputSystem_Actions _actions = new();
        
        public InputHandler()
        {
            Instance = this;
            
            _actions.Enable();
            
            _actions.Player.Mouse.performed += ctx => OnMouseMove?.Invoke(ctx.ReadValue<Vector2>());
            _actions.UI.Pause.performed += _ => OnPause?.Invoke();
            _actions.UI.ToMenu.performed += _ => OnToMainMenu?.Invoke();
        }
    }
}