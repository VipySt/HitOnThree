using System.Collections.Generic;

using UnityEngine;

namespace ScriptsUnity.HealthBar
{
    [System.Serializable]
    public struct HealthStepsStruct
    {        
        #region ErrorSets
        const int _BAN_VALUE_HEALTH = -1;
        const string _ERR_IN_HEALTH_NEGATIVE = "Error. Input health less then -1";
        #endregion

        public int Health
        {
            get { return _health; }
            set
            {
                if (value > _BAN_VALUE_HEALTH)
                    _health = value;
                else throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_NEGATIVE);
            }
        }
        public Color ColorStep;

        public HealthStepsStruct(int maxHealth, Color color)
        {
            if (maxHealth > _BAN_VALUE_HEALTH)
                _health = maxHealth;
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_NEGATIVE);

            ColorStep = color;
        }
        

        private int _health;
    }

    [System.Serializable]
    public class HealthStep : MonoBehaviour
    {
        #region ErrorValues
        const int _BAN_VALUE_HEALTH = -1;
        const string _ERR_IN_STEPS_COUNT_ZERO = "Error. Count of Steps health equel 0";
        const string _ERR_IN_HEALTH_MAX_NEGATIVE = "Error. Input MaxHealth is negative";
        const string _ERR_LAST_STEP_NOT_EQUEL_MAX_HEALTH = "Error. Last value Health by Steps most be equel MaxHealth";
        const string _ERR_IN_HEALTH_MORE_MAX = "Error input health more then MaxHealth";
        #endregion

        public int MaxHealth
        {
            get { return _health; }
            set
            {
                if (value > _BAN_VALUE_HEALTH)
                    _health = value;
                else throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_MAX_NEGATIVE);
            }
        }
        public HealthStepsStruct[] Steps;


        private int _health;


        public HealthStepsStruct GetStep(int healthNow)
        {
            if (healthNow <= MaxHealth) { }
            else throw new System.ArgumentException(_ERR_IN_HEALTH_MORE_MAX);

            const int START_INDEX = 0;
            int currentIndex = START_INDEX;

            for (int i = START_INDEX; i < Steps.Length; ++i)
                if (healthNow > Steps[i].Health) {}
                else
                {
                    currentIndex = i;
                    break;
                }


            return Steps[currentIndex];
        }


        private void Awake()
        {
            const int EMPTY_MASS = 0;

            if (Steps.Length == EMPTY_MASS)
                throw new System.ArgumentException(_ERR_IN_STEPS_COUNT_ZERO);
        }

        
        
    }
}
