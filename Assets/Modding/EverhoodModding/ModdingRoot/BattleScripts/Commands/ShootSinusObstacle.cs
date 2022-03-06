using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    [EventCommandInfo("Battle Events", "Shoot sinus projectile")]
    public class ShootSinusObstacle : EventCommand
    {
        public GameObject prefab;

        public bool jumpable = true;

        public float speed = 20;

        [Range(0, 100)]
        public float waveHeightX = 0;
        [Range(0, 100)]
        public float waveHeightY = 0;

        [Space(5)]

        [Range(0, 100)]
        public float waveSpeedX = 0;
        [Range(0, 100)]
        public float waveSpeedY = 0;

        [Space(5)]
        public bool customStartTimeSinWave = false;
        public float startTimeSinWaveX = 0;
        public float startTimeSinWaveY = 0;

        public override void Execute()
        {

        }
    }
}
