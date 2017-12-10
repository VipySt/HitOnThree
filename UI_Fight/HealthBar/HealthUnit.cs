using System.Collections.Generic;

using UnityEngine;
using ScriptsUnity.EffectsFightByUnit;

namespace ScriptsUnity.HealthBar
{
    [System.Serializable]
    public struct HealthStepsStruct
    {
        #region ErrorSets
        const int _BAN_VALUE_HEALTH = -1;
        const string _ERR_IN_HEALTH_NEGATIVE = "Error. Input health less then -1";
        #endregion


        public int Health;
        public Color ColorStep;

        public HealthStepsStruct(int maxHealth, Color color)
        {
            if (maxHealth > _BAN_VALUE_HEALTH)
                Health = maxHealth;
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_NEGATIVE);

            ColorStep = color;
        }
    }

    //[System.Serializable]
    public class HealthUnit : MonoBehaviour
    {
        #region ErrorData
        const string _ERR_IN_HEALTH_STEP_NULL = "Error. Massive of steps health is null";
        const string _ERR_IN_HEALTH_STEP_EMPTY = "Error. Massive of steps health is empty";
        const string _ERR_IN_HEALTH_BAR_OBJ_NULL = "Error. GameObject HealthBarObj not set";
        #endregion

        #region Consts
        const int _EMPTY_MASS = 0;
        #endregion


        public int HealthMax;
        public int Health;
        public float ProcentFloat;
        public int EnergyMax;
        public int Energy;
        public string nameObject = string.Empty;

        public AbsHealthBar HealthBarObj = null;
        public HealthStepsStruct[] Steps = null;
        

        private void Awake()
        {
            if (Steps == null)
                throw new System.Exception(_ERR_IN_HEALTH_STEP_NULL);
            else if (Steps.Length == _EMPTY_MASS)
                throw new System.Exception(_ERR_IN_HEALTH_STEP_EMPTY);

            if (HealthBarObj == null)
                throw new System.Exception(_ERR_IN_HEALTH_BAR_OBJ_NULL);
        }

        private void Start()
        {
            HealthBarObj.InitHealthBar(nameObject, HealthMax, EnergyMax);
            HealthBarObj.SetCountHealth(Health, Steps[FindStepIndex(Health)].ColorStep);
            HealthBarObj.SetEnegyPoints(Energy);
        }
        
        private int FindStepIndex(int health)
        {
            const int START_MASSIVE = 0;

            int result = START_MASSIVE;
            for (int i = START_MASSIVE; i < Steps.Length; ++i)
                if (health > Steps[i].Health) { }
                else
                {
                    result = i;
                    break;
                }

            return result;
        }
    }
}
