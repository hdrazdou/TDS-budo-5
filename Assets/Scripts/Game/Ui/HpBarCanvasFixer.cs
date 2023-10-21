using UnityEngine;

namespace TDS.Game.Ui
{
    public class HpBarCanvasFixer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _mainTransform;

        private Vector3 _startPosition;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        private void Update()
        {
            transform.up = Vector3.up;

            Quaternion rotation = Quaternion.FromToRotation(_mainTransform.up, Vector3.up);
            transform.localPosition = rotation * _startPosition;
        }

        #endregion
    }
}