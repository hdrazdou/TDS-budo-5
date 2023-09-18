using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class HpBooster : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp unitHp))
            {
                unitHp.Change(_hp);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}