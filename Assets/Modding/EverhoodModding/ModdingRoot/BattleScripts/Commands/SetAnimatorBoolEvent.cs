using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{

    [AddComponentMenu("Everhood/EventCommands/SetAnimatorBoolEvent")]
    [EventCommandInfo("Animator", "Set bool")]
    public class SetAnimatorBoolEvent : EventCommand
    {
        public void SetParameters(Animator animator, string boolVariableName, bool state)
        {
            this.animator = animator;
            this.boolVariableName = boolVariableName;
            this.state = state;
        }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string boolVariableName;

        [SerializeField]
        private bool state;

        public override void Execute()
        {
            animator.SetBool(boolVariableName, state);
        }
    }
}
