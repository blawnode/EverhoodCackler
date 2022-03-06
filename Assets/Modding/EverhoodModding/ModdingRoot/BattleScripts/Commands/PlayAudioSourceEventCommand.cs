using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    [AddComponentMenu("Everhood/EventCommands/PlayAudioSource")]
    [EventCommandInfo("FX", "Play AudioSource")]
    public class PlayAudioSourceEventCommand : EventCommand
    {
        [SerializeField]
        private AudioSource source;

        public override void Execute()
        {
            source.Play();
        }
    }
}
