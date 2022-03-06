using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    [AddComponentMenu("Everhood/EventCommands/SetActiveEvent")]
    [EventCommandInfo("Script", "Set Active")]
    public class SetActiveEventCommand : EventCommand
    {
        public void SetParameters(GameObject target, bool state)
        {
            this.target = target;
            this.state = state;
        }

        [SerializeField]
        private GameObject target;

        [SerializeField]
        private bool state;

        public override void Execute()
        {
            target.SetActive(state);
        }


    }
}
