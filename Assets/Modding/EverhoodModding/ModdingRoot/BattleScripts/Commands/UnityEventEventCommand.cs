using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EverhoodModding
{
    [AddComponentMenu("Everhood/EventCommands/UnityEventEventCommand")]
    [EventCommandInfo("Script", "UnityEvent")]
    public class UnityEventEventCommand : EventCommand
    {
        public UnityEvent unityEvent;

        public override void Execute()
        {
            unityEvent?.Invoke();
        }


    }
}
