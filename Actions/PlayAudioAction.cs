using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InspectorAction
{
    public class PlayAudioAction : AbstractAction
    {
        AudioClip clip;
        bool wait;
        public PlayAudioAction( AudioClip clip,Action completeAction,bool wait) : base (completeAction)
        {
            this.clip = clip;
            this.wait = wait;
        }

        public override void Call()
        {
            AudioSource source = MainManager.Instance.mainCamera.GetComponent<AudioSource>();
            source.clip = clip;
            source.Play();
            if (!wait)
            {
                completeAction();
            } else
            {
               StartCoroutine(WaitPlay(source));
            }

          
        }
        IEnumerator WaitPlay(AudioSource audio)
        {
            while (audio.isPlaying)
            {
                yield return null;
            }
            completeAction();
        }
    }
}
