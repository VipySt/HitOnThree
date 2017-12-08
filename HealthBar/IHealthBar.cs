using System.Collections.Generic;

using UnityEngine;

namespace HitOnThree.git.HealthBar
{
    public interface IHealthBar
    {
        void InitHealthBar(int healthNow, HealthStep stepsHealth);
    }
}
