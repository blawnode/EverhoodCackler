using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{

    [AddComponentMenu("Everhood/EventCommands/SetAnimatorRandomInteger")]
    [EventCommandInfo("Animator", "Set random integer")]
    public class SetAnimatorRandomInteger : EventCommand
    {
        public void SetParameters(Animator animator, string integerVariableName, int min, int max)
        {
            this.animator = animator;
            this.integerVariableName = integerVariableName;
            this.min = min;
            this.max = max;
        }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string integerVariableName;

        [SerializeField]
        private int min, max;

        private int _previousNumber;


        public override void Execute()
        {
            animator.SetInteger(integerVariableName, GetRandomNumber());
        }

        private int GetRandomNumber()
        {
            int randomNumber = Random.Range(min, max);

            if (randomNumber == _previousNumber)
            {
                randomNumber++;
                randomNumber = randomNumber >= max ? 0 : randomNumber;
            }

            _previousNumber = randomNumber;

            return randomNumber;
        }
    }
}
