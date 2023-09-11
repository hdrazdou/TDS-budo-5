using TDS.Game.Player;
using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class HpBooster : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp;
        [SerializeField] private LayerMask _layerMask;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("HpBooster OnTriggerEnter2D");

            if ((_layerMask.value & (1 << other.gameObject.layer)) != 0)
            {
                PlayerHpService playerHpService;
                if (other.TryGetComponent(out playerHpService))
                {
                    playerHpService.Hp += _hp;
                    Destroy(gameObject);
                }
            }
        }

        #endregion
    }
}