using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsUnity.FightTime
{

    public class ViewTimeFight : MonoBehaviour
    {
        #region ErrorValues
        const string _ERR_NULL_TIME_LEFT_VIEW = "Error. Not setted TimeLeftView. Value is null";
        const string _ERR_NULL_TIME_MASK_LEFT = "Error. Not setted TimeMaskLeft. Value is null";
        const string _ERR_NULL_TEXT_TIME_VIEW = "Error. Not setted TextTimerView. Value is null";
        #endregion

        #region Consts Private
        private const float _MAX_FILL_AMOUNT = 1.0f;
        private const float _TIMER_ZERO = 0.0f;
        #endregion

        #region Consts Public
        public const float NORMAL_MULTY_SPEED_TIMER = 1.0f;
        #endregion

        public Image TimeLeftView = null;
        public Image TimeMaskLeft = null;
        public Text TextTimerView = null;
        public float MaxTimeRound = 3.0f;
        public float MultyTimerSpeed = NORMAL_MULTY_SPEED_TIMER;

        public Color ColorBase;
        public Color ColorActicon;

        private float _timerRound = 0.0f;
        private bool _working = false;


        public void ResetTime()
        {
            TimeMaskLeft.gameObject.SetActive(false);

            TimeLeftView.color = ColorBase;
            TimeMaskLeft.fillAmount = _MAX_FILL_AMOUNT;

            _timerRound = _TIMER_ZERO;
            RecountTimer();
        }

        public void StartTimer()
        {
            _working = true;
        }

        public void StopTimer()
        {
            _working = false;
        }


        public float AddActicionTime(float timeAction)
        {
            float delta;

            if (TimeMaskLeft.gameObject.activeInHierarchy)
            {
                float amount = TimeMaskLeft.fillAmount - timeAction / MaxTimeRound;
                if (amount > 0)
                {
                    TimeMaskLeft.fillAmount = amount;
                    delta = amount * MaxTimeRound;
                }
                else delta = -1;
            }
            else
            {
                delta = MaxTimeRound - _timerRound - timeAction;

                if (delta >= _TIMER_ZERO)
                {
                    var tScale = delta / MaxTimeRound;

                    TimeLeftView.color = ColorActicon;

                    TimeMaskLeft.gameObject.SetActive(true);
                    TimeMaskLeft.color = ColorBase;
                    TimeMaskLeft.fillAmount = tScale;
                }
            }
                        

            return delta;
        }


        private void RecountTimer()
        {
            var delta = MaxTimeRound - _timerRound;
            TimeLeftView.fillAmount = delta / MaxTimeRound;
            TextTimerView.text = string.Format("End round to {0:F2}", delta);

            if (TimeMaskLeft.gameObject.activeInHierarchy)
            {
                if (TimeMaskLeft.fillAmount < TimeLeftView.fillAmount) { }
                else
                {
                    TimeMaskLeft.gameObject.SetActive(false);
                    TimeLeftView.color = ColorBase;
                }
            }

            if (delta <= _TIMER_ZERO)
            {
                delta = 0;
                TextTimerView.text = string.Format("End round to 0.00");
                StopTimer();
            } //Время рауна вышло
        }


        private void Awake()
        {
            if (!TimeLeftView)
                throw new System.ArgumentNullException(_ERR_NULL_TIME_LEFT_VIEW);
            if (!TimeMaskLeft)
                throw new System.ArgumentNullException(_ERR_NULL_TIME_MASK_LEFT);
            if (!TextTimerView)
                throw new System.ArgumentNullException(_ERR_NULL_TEXT_TIME_VIEW);
        }

        private void FixedUpdate()
        {
            if (!_working) return;

            _timerRound += Time.deltaTime * MultyTimerSpeed;
            RecountTimer();
        }

    }
}
