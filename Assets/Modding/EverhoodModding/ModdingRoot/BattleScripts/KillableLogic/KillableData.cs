using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{
    public class KillableData : MonoBehaviour
    {
        public int noobHp = 25;

        public int storyModeHp = 25;

        public int easyModeHp = 25;

        public int standardModHp = 25;

        public int hardModHp = 25;

        public int insaneHp = 25;

        [Space(10)]
        public bool loopableBattle = false;
        [Space(5)]
        public bool loopableInSpecificTime = false;
        public float loopableStart;
        public float loopableEnd;

    }
}
