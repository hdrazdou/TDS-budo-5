using UnityEngine;

namespace TDS.Game
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _follow;
        [SerializeField] private float _z = -10f;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Vector3 followPosition = _follow.position;
            followPosition.z = _z;
            transform.position = followPosition;
        }

        #endregion
    }
}