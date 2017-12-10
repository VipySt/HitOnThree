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
        const int _BAN_POINTS_ENERGY = -1;

        const string _ERR_EMPTY_IN_NAME = "Error. Input name is empty or null";
        const string _ERR_IN_MAX_HEALTH_NEGATIVE = "Error. Input maxHealth is negative";
        const string _ERR_IN_HEALTH_BIGGER_MAX_HEALTH = "Error. Input health is bigger then maxHealth";
        const string _ERR_IN_POINTS_ENERGY_NEGATIVE = "Error. Input energy poinst is negative";
        const string _ERR_IN_MAX_POITS_ENERGY_NEGATIVE = "Error. Input maxEnergy poits is negatuve";
        const string _ERR_IN_POINTS_ENERGY_BIGGER_MAX = "Error. Input energy points is bigger then maxEnergyPoints";

        const string _ERR_NULL_TEXT_NAME = "Error. Input textNameUnit is null";
        const string _ERR_NULL_IMAGE_HEALTH = "Error. Input ImageViewHealth is null";
        const string _ERR_NULL_TEXT_HEALTH = "Error. Input TextViewValueHealth is null";
        const string _ERR_NULL_IMAGE_ENERGY = "Error. Input ImageEnergy is null";
        const string _ERR_NULL_TEXT_ENERGY = "Error. Input TextEnegryPoints us null";
        const string _ERR_SETTINGS_IMAGE = "Error. Settings of image wrong. ImageType 'Filled', Method 'Horizontal'";
        #endregion

        public float ProcentFullHealth;

        public Text TextNameUnit = null;
        public Text TextViewValueHealth = null;
        public Image ImageViewHealth = null;
        public Image ImageViewEnegy = null;
        public Text TextEnergyPoints = null;

        public bool InverseViewHealth = false;

        private int _maxHealth;
        private int _healt;

        private int _maxEnergyPoints;
        
        public override void InitHealthBar(string name, int maxHealth, int maxEnergy)
        {
            if (!string.IsNullOrEmpty(name))
                TextNameUnit.text = name;
            else throw new System.ArgumentException(_ERR_EMPTY_IN_NAME);

            if (maxHealth > _BAN_HEALTH)
                _maxHealth = maxHealth;
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_MAX_HEALTH_NEGATIVE);

            if (maxEnergy > _BAN_POINTS_ENERGY)
                _maxEnergyPoints = maxEnergy;
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_MAX_POITS_ENERGY_NEGATIVE);
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

                var healthValueView = (InverseViewHealth) ? string.Format("{0} / {1}", health, _maxHealth)
                                                          : string.Format("{0} / {1}", _maxHealth, health);

                TextViewValueHealth.text = healthValueView;
            }

            ImageViewHealth.color = color;
        }

        public override void SetEnegyPoints(int points)
        {
            if (points > _BAN_POINTS_ENERGY) { }
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_POINTS_ENERGY_NEGATIVE);

            if (points <= _maxEnergyPoints) { }
            else throw new System.ArgumentOutOfRangeException(_ERR_IN_POINTS_ENERGY_BIGGER_MAX);

            TextEnergyPoints.text = points.ToString();
            ImageViewEnegy.fillAmount = (float)points / _maxEnergyPoints;
        }


        private void Awake()
        {
            if (TextNameUnit == null)
                throw new System.ArgumentNullException(_ERR_NULL_TEXT_NAME);
            if (ImageViewHealth == null)
                throw new System.ArgumentNullException(_ERR_NULL_IMAGE_HEALTH);
            if (TextViewValueHealth == null)
                throw new System.ArgumentNullException(_ERR_NULL_TEXT_HEALTH);
            if (ImageViewEnegy == null)
                throw new System.ArgumentNullException(_ERR_NULL_IMAGE_ENERGY);
            if (TextEnergyPoints == null)
                throw new System.ArgumentNullException(_ERR_NULL_TEXT_ENERGY);


            ImageViewHealth.type = Image.Type.Filled;
            ImageViewHealth.fillMethod = Image.FillMethod.Horizontal;
            ImageViewHealth.fillOrigin = (InverseViewHealth) ? (int)Image.OriginHorizontal.Right
                                                             : (int)Image.OriginHorizontal.Left;
        }

    }
}
