using NaughtyAttributes;
using Pathfinding;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class AiPathMovement : EnemyComponent
    {
        #region Variables

        [SerializeField] private GameObject _enemyMovementAgro;
        [SerializeField] private bool _needsReturn;

        [ShowNonSerializedField]
        private AIDestinationSetter _aiDestinationSetter;

        [ShowNonSerializedField]
        private AIPath _aiPath;

        [ShowNonSerializedField]
        private Seeker _seeker;

        private Transform _startPositionTransform;

        [ShowNonSerializedField]
        private TriggerObserver _triggerObserver;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPositionTransform = new GameObject($"{gameObject.name} Start Point").transform;
            _startPositionTransform.position = transform.position;
        }

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
            _seeker = GetComponent<Seeker>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();

            _triggerObserver = _enemyMovementAgro.GetComponent<TriggerObserver>();

            _triggerObserver.OnExit += OnObserverExit;
            _triggerObserver.OnStay += OnObserverStay;
        }

        #endregion

        #region Private methods

        private void OnObserverExit(Collider2D other)
        {
            _aiDestinationSetter.target = null;

            _aiDestinationSetter.enabled = false;
            _aiPath.enabled = false;
            _seeker.enabled = false;

            if (_needsReturn)
            {
                _aiDestinationSetter.enabled = true;
                _aiPath.enabled = true;
                _seeker.enabled = true;

                _aiDestinationSetter.target = _startPositionTransform;
            }
        }

        private void OnObserverStay(Collider2D other)
        {
            _aiDestinationSetter.enabled = true;
            _aiPath.enabled = true;
            _seeker.enabled = true;

            _aiDestinationSetter.target = other.transform;
        }

        #endregion
    }
}