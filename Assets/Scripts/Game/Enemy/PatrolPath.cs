using UnityEngine;

namespace TDS.Game.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform[] _points;

        private int _currentIndex;

        #endregion

        #region Properties

        public Transform[] Points => _points;

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