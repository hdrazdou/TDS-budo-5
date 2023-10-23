using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.Ui
{
    public class JoystickInputView : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _attackButton;
        [SerializeField] private bl_Joystick _movementJoystick;
        [SerializeField] private float _movementAxesRatio = 5f;

        [SerializeField] private bl_Joystick _rotationJoystick;
        [SerializeField] private float _rotationAxesRatio = 5f;

        #endregion

        #region Events

        public event Action OnAttackButtonClicked;

        #endregion

        #region Properties

        public Vector2 MovementAxes =>
            new(_movementJoystick.Horizontal / _movementAxesRatio, _movementJoystick.Vertical / _movementAxesRatio);

        public Vector3 RotationAxes =>
            new(_rotationJoystick.Horizontal / _rotationAxesRatio, _rotationJoystick.Vertical / _rotationAxesRatio);

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attackButton.onClick.AddListener(OnClick);
        }

        #endregion

        #region Private methods

        private void OnClick()
        {
            OnAttackButtonClicked?.Invoke();
        }

        #endregion
    }
}