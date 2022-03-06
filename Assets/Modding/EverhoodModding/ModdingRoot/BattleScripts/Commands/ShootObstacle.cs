using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    [EventCommandInfo("Battle Events", "Shoot projectile")]
    public class ShootObstacle : EventCommand
    {
        public GameObject prefab;

        public bool jumpable = true;

        public float speed = 20;

        public override void Execute()
        {

        }
    }
}
