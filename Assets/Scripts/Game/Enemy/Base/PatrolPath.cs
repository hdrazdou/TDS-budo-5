using UnityEngine;

namespace TDS.Game.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform[] _points;

        private int _currentIndex;

        #endregion

        #region Unity lifecycle

        private void OnDrawGizmos()
        {
            if (_points == null || _points.Length == 0)
            {
                return;
            }

            Gizmos.color = Color.cyan;
            Vector3 previousPosition = _points[0].position;
            Gizmos.DrawSphere(previousPosition, 0.2f);

            for (int i = 1; i < _points.Length; i++)
            {
                Vector3 currentPosition = _points[i].position;
                Gizmos.DrawSphere(currentPosition, 0.2f);

                Gizmos.DrawLine(previousPosition, currentPosition);

                previousPosition = currentPosition;
            }

            Gizmos.DrawLine(previousPosition, _points[0].position);
        }

        #endregion

        #region Public methods

        public void FillPoints()
        {
            _points = new Transform[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                _points[i] = transform.GetChild(i);
            }
        }

        public Transform GetCurrentPoint()
        {
            return _points[_currentIndex];
        }

        public void SetNextPoint()
        {
            _currentIndex++;
            if (_currentIndex >= _points.Length)
            {
                _currentIndex = 0;
            }
        }

        #endregion
    }
}