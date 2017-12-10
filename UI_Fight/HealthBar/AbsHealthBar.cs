using System.Collections.Generic;

using UnityEngine;

namespace ScriptsUnity.HealthBar
{ 
    public abstract class AbsHealthBar : MonoBehaviour
    {
        public virtual void InitHealthBar(string name, int maxHealth, int maxEnery) { }
        public virtual void SetCountHealth(int health, Color color) { }

        public virtual void SetEnegyPoints(int points) { }
    }
}
