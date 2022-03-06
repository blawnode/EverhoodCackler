using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    public class OnFinalDamageEventHolder : MonoBehaviour
    {
        private void Reset()
        {
            if (GetComponent<EventsCreator>() == null)
                gameObject.AddComponent<EventsCreator>();
        }
    }
}
