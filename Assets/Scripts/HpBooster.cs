using TDS.Game.Player;
using UnityEngine;

namespace TDS
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
            Debug.Log("HpBooster OnTriggerEnter2D");

            if (other.TryGetComponent(out PlayerHp playerHp))
            {
                playerHp.Hp += _hp;
                Destroy(gameObject);
            }
        }

        #endregion
    }
}