using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace ScriptsUnity.HealthBar
{
    public class HealthBar : AbsHealthBar
    {
        #region ErrorValues
        const int _BAN_HEALTH = -1;

        const string _ERR_EMPTY_IN_NAME = "Error. Input name is empty or null";
        const string _ERR_IN_MAX_HEALTH_NEGATIVE = "Error. Input maxHealth is negative";
        const string _ERR_IN_HEALTH_BIGGER_MAX_HEALTH = "Error. Input health is bigger then maxHealth";

        const string _ERR_NULL_TEXT = "Error. Input textNameUnit is null";
        const string _ERR_NULL_IMAGE = "Error. Input ImageViewHealth is null";
        const string _ERR_SETTINGS_IMAGE = "Error. Settings of image wrong. ImageType 'Filled', Method 'Horizontal'";
        #endregion

        public float ProcentFullHealth;

        public Text TextNameUnit = null;
        public Image ImageViewHealth = null;

        private int _maxHealth;
        private int _healt;

        
        public override void InitHealthBar(string name, int maxHealth)
        {
            if (!string.IsNullOrEmpty(name))
                TextNameUnit.text = name;
            else throw new System.ArgumentException(_ERR_EMPTY_IN_NAME);

            if (maxHealth > _BAN_HEALTH)
                _maxHealth = maxHealth;
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_MAX_HEALTH_NEGATIVE);
        }

        public override void SetCountHealth(int health, Color color)
        {
            if (health <= _maxHealth) { }
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_HEALTH_BIGGER_MAX_HEALTH);

            if (health != _healt)
            {
                _healt = (health > _BAN_HEALTH) ? health : 0;
                ProcentFullHealth = (float)_healt / _maxHealth;
                ImageViewHealth.fillAmount = ProcentFullHealth;
            }

            ImageViewHealth.color = color;
        }


        private void Awake()
        {
            if (TextNameUnit == null)
                throw new System.ArgumentNullException(_ERR_NULL_TEXT);
            if (ImageViewHealth == null)
                throw new System.ArgumentNullException(_ERR_NULL_IMAGE);

            ImageViewHealth.type = Image.Type.Filled;
            ImageViewHealth.fillMethod = Image.FillMethod.Horizontal;
        }

    }
}
