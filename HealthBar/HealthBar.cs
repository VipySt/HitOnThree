using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptsUnity.HealthBar
{
    public class HealthBar : MonoBehaviour, IHealthBar
    {
        public int Health;
        private HealthStep _stepViewHealth = null;

        #region ErrorMessages
        private const string _ERR_IN_NULL_STEPS_CLASS = "Error input stepsHealth is null";
        private const string _ERR_IN_HEALTH_VALUE = "Error input health value. HealthNow bigger then max_health";
        #endregion

        public void InitHealthBar(int healthNow, HealthStep stepsHealth)
        {
            if (stepsHealth != null)
                _stepViewHealth = stepsHealth;
            else
                throw new System.ArgumentNullException(_ERR_IN_NULL_STEPS_CLASS);

            if (healthNow <= _stepViewHealth.MaxHealth)
                Health = healthNow;
            else
                throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_VALUE);
        }


    }
}
