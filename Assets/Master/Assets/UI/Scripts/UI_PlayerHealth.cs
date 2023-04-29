using UnityEngine;
using UnityEngine.UI;
namespace ScottBarley.IGB100.V1
{
    public class UI_PlayerHealth : MonoBehaviour
    {
        public Image[] _heartImages;  // Array of UI heart images
        public Transform _remainderHeart;
        public RectTransform _scalableRectTransfrom;  // Array to store the original scales of the hearts
        private int _totalHearts;

        //public float _shrinkSpeed = 2f;  // Speed at which the hearts shrink

        int _fullHeartsRemaining;
        float _pctEachHeartIs;
        float _remainderPct;

        private void Awake()
        {
            _remainderHeart.gameObject.SetActive(false);
            _totalHearts = _heartImages.Length;
            _pctEachHeartIs = 1f / _totalHearts;
        }

        public void fn_UpdateHealth(float healthPercentage)
        {
            // Calculate the number of hearts to turn off based on the percentage
            _fullHeartsRemaining = Mathf.FloorToInt(_totalHearts * healthPercentage);           
            _remainderPct = healthPercentage - (_pctEachHeartIs * _fullHeartsRemaining);

            // Disable All
            foreach (var heartImg in _heartImages)
            {
                heartImg.gameObject.SetActive(false);
            }
            _remainderHeart.gameObject.SetActive(false);

            // Enable Full Hearts remaining heart images
            for (int i = 0; i < _fullHeartsRemaining; i++)
            {
                _heartImages[i].gameObject.SetActive(true);
            }

            // Enable Remainder Heart

            if (_remainderPct > 0)
            {
                _scalableRectTransfrom.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, _remainderPct / _pctEachHeartIs);
                _remainderHeart.gameObject.SetActive(true);
                
            }
        }
    }
}