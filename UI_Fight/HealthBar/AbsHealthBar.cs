using System.Collections.Generic;

using UnityEngine;

namespace ScriptsUnity.HealthBar
{ 
    public abstract class AbsHealthBar : MonoBehaviour
    {
        public virtual void InitHealthBar(string name, int maxHealth) { }
        public virtual void SetCountHealth(int health, Color color) { }
    }
}
