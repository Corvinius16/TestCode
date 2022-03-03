using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace InspectorAction
{
    public class AnimationModelAction : AbstractAction
    {


        private string trigger;
        private bool isWait;
        private Animator animator;
        public AnimationModelAction(string trigger,bool isWait, Action completeAction) : base(completeAction)
        {
            this.trigger = trigger;
            this.isWait = isWait;
         
        }



        public override void Call()
        {
            animator = MainManager.Instance.InspectorModel.GetComponent<Animator>();
            if(trigger=="StopMove")
            {
                animator.enabled = false;
            }
            else
            {
                animator.enabled = true;
            }
            animator.SetTrigger(trigger);
            if (!isWait)
            {
                completeAction();
            }
           
        }


  
    }
}