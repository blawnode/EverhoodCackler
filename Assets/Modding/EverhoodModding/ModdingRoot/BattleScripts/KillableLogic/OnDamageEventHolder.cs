using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    public class OnDamageEventHolder : MonoBehaviour
    {
        private void Reset()
        {
            if (GetComponent<EventsCreator>() == null)
                gameObject.AddComponent<EventsCreator>();
        }
    }
}
