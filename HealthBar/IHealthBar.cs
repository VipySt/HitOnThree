using System.Collections.Generic;

using UnityEngine;

namespace ScriptsUnity.HealthBar
{
    public interface IHealthBar
    {
        void InitHealthBar(int healthNow, HealthStep stepsHealth);
    }
}
