using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    [AddComponentMenu("Everhood/EventCommands/PlayParticles")]
    [EventCommandInfo("FX", "Play particles")]
    public class PlayParticleEventCommand : EventCommand
    {
        [SerializeField]
        private ParticleSystem particleSystem;

        public void SetParticle(ParticleSystem particle) => particleSystem = particle;

        public override void Execute()
        {
            particleSystem.Play();
        }
    }
}
