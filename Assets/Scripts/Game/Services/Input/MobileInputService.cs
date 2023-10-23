using System;
using TDS.Game.Ui;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TDS.Game.Services.Input
{
    public class MobileInputService : IInputService
    {
        #region Variables

        private const string PrefabPath = "UI/JoystickInputView";

        private JoystickInputView _inputView;
        private JoystickInputView _inputViewPrefab;

        #endregion

        #region Events

        public event Action OnAttack;

        #endregion

        #region Properties

        public Vector2 Axes => _inputView.MovementAxes;
        public Vector3 LookDirection => _inputView.RotationAxes;

        #endregion

        #region IInputService

        public void Dispose()
        {
            _inputView.OnAttackButtonClicked -= OnAttackButtonClicked;

            Object.Destroy(_inputView.gameObject);
            _inputView = null;
        }

        public void Initialize(Camera camera, Transform playerMovementTransform)
        {
            LoadPrefab();
            InstantiateView();

            _inputView.OnAttackButtonClicked += OnAttackButtonClicked;
        }

        #endregion

        #region Private methods

        private void InstantiateView()
        {
            _inputView = Object.Instantiate(_inputViewPrefab);
        }

        private void LoadPrefab()
        {
            if (_inputViewPrefab == null)
            {
                _inputViewPrefab = Resources.Load<JoystickInputView>(PrefabPath);
            }
        }

        private void OnAttackButtonClicked()
        {
            OnAttack?.Invoke();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                OnAttack?.Invoke();
            }
        }

        #endregion
    }
}