using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            StateMachine sm = new();
            ServiceLocator.Instance.Register(sm);
            sm.Enter<BootstrapState>();
        }

        #endregion
    }
}