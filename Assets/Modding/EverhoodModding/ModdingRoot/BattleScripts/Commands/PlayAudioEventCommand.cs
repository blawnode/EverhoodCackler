using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace EverhoodModding
{
    [AddComponentMenu("Everhood/EventCommands/PlayAudio")]
    [EventCommandInfo("FX", "Play audio")]
    public class PlayAudioEventCommand : EventCommand
    {
        [SerializeField]
        private AudioClip audioClip;
        [SerializeField]
        [Range(0, 256)]
        private int priority = 128;
        [SerializeField]
        [Range(0, 1)]
        private float volume = 1f;
        [SerializeField]
        [Range(-3, 3)]
        private float pitch = 1f;

        private AudioSource _source;

        private void Awake()
        {




            _source = new GameObject("[AudioSourceInstance]").AddComponent<AudioSource>();
            _source.hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInBuild;
            _source.gameObject.hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInBuild;

            _source.priority = priority;
            _source.playOnAwake = false;
            _source.volume = volume;
            _source.pitch = pitch;

 
        }

       

        public override void Execute()
        {
            _source.PlayOneShot(audioClip);
        }
    }
}
