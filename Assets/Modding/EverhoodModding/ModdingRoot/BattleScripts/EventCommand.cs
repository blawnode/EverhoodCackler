using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{

    public abstract class EventCommand : MonoBehaviour  
    {
        public abstract void Execute();
    }
}
