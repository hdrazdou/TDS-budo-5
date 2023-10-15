using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.Ui
{
    public class HpBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Image _image;
        [SerializeField] private UnitHp _unitHp;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (_unitHp == null)
            {
                return;
            }

            Init();
        }

        private void Start()
        {
            if (_unitHp == null)
            {
                return;
            }

            Init();
        }

        private void Update() { }

        private void OnDestroy()
        {
            Dispose();
        }

        #endregion

        #region Public methods

        public void Construct(UnitHp unitHp)
        {
            Dispose();

            _unitHp = unitHp;

            Init();
        }

        #endregion

        #region Private methods

        private void Dispose()
        {
            if (_unitHp != null)
            {
                _unitHp.OnChanged -= OnHpChanged;
            }
        }

        private void Init()
        {
            _unitHp.OnChanged += OnHpChanged;
            UpdateBar();
        }

        private void OnHpChanged(int obj)
        {
            UpdateBar();
        }

        private void UpdateBar()
        {
            _image.fillAmount = _unitHp.Current / (float)_unitHp.Max;
        }

        #endregion
    }
}