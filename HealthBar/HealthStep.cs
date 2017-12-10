using System.Collections.Generic;

using UnityEngine;

namespace ScriptsUnity.HealthBar
{
    

    [System.Serializable]
    public class HealthStep : MonoBehaviour
    {
        #region ErrorValues
        const int _BAN_VALUE_HEALTH = -1;
        const string _ERR_IN_STEPS_COUNT_ZERO = "Error. Count of Steps health equel 0";
        const string _ERR_IN_HEALTH_MAX_NEGATIVE = "Error. Input MaxHealth is negative";
        const string _ERR_IN_STEPS_LAST_HEALTH_NOT_EQUEL_MAX_HEALTH = "Error. Input last Health Steps value not equel MaxHealth";
        const string _ERR_LAST_STEP_NOT_EQUEL_MAX_HEALTH = "Error. Last value Health by Steps most be equel MaxHealth";
        const string _ERR_IN_HEALTH_MORE_MAX = "Error input health more then MaxHealth";
        #endregion

        public int MaxHealth;
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

            if (Steps[Steps.Length - 1].Health != MaxHealth)
                throw new System.ArgumentOutOfRangeException(_ERR_IN_STEPS_LAST_HEALTH_NOT_EQUEL_MAX_HEALTH);

            if (MaxHealth < _BAN_VALUE_HEALTH)
                throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_MAX_NEGATIVE);
        }

        
        
    }
}
