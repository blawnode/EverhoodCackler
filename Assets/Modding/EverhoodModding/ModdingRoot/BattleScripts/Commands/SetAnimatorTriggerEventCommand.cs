using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{

    [AddComponentMenu("Everhood/EventCommands/SetAnimatorTriggerEvent")]
    [EventCommandInfo("Animator", "Set trigger")]
    public class SetAnimatorTriggerEventCommand : EventCommand
    {
        public void SetParameters(Animator animator, string triggerVariableName)
        {
            this.animator = animator;
            this.triggerVariableName = triggerVariableName;
        }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string triggerVariableName;         

        public override void Execute()
        {
            animator.SetTrigger(triggerVariableName);
        }
    }
}
