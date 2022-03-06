using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    public class NpcHealthEventHolder : MonoBehaviour
    {
        public int hpTarget = 25;

        private void Reset()
        {
            if (GetComponent<EventsCreator>() == null)
                gameObject.AddComponent<EventsCreator>();
        }
    }
}
