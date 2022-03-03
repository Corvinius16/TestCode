using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
namespace InspectorAction
{
    public class AbstractAction
    {

        protected Action completeAction;

        public AbstractAction(Action completeAction)
        {
            this.completeAction = completeAction;
            MainManager.Instance.Scenario.CompleteAction = completeAction;
        }

  

        public void StartCoroutine(IEnumerator coroutine)
        {
            MainThreadDispatcher.StartUpdateMicroCoroutine(coroutine);
        }

        public virtual void Call()
        {

        }

        protected IDisposable Subscribe(ReferenceObject reference, TypeAction type, Action action)
        {
            switch (type)
            {
                case TypeAction.Update:
                    {
                        return reference.UpdateAsObservable().Subscribe((x) => action());
                        
                        break;
                    }
                case TypeAction.FixedUpdate:
                    {
                        return reference.FixedUpdateAsObservable().Subscribe((x) => action());
                        break;
                    }
                case TypeAction.LateUpdate:
                    {
                        return reference.LateUpdateAsObservable().Subscribe((x) => action());
                        break;
                    }
                  
            }
            return null;
        }

        protected IDisposable Subscribe<T>(ReferenceObject reference, TypeAction type, Action<T> action)
        {
            switch (type)
            {
                case TypeAction.OnCollisionEnter:
                    {
                        //reference.OnCollisionEnterAsObservable().
                        return  reference.OnCollisionEnterAsObservable().Subscribe(action as Action<Collision>);
                        break;
                    }
                case TypeAction.OnCollisionExit:
                    {
                        return reference.OnCollisionExitAsObservable().Subscribe(action as Action<Collision>);
                        break;
                    }
                case TypeAction.OnCollisionStay:
                    {
                        return reference.OnCollisionStayAsObservable().Subscribe(action as Action<Collision>);
                        break;
                    }
                case TypeAction.OnTriggerEnter:
                    {
                        return reference.OnTriggerEnterAsObservable().Subscribe(action as Action<Collider>);
                        break;
                    }
                case TypeAction.OnTriggerExit:
                    {
                        return reference.OnTriggerExitAsObservable().Subscribe(action as Action<Collider>);
                        break;
                    }
                case TypeAction.OnTriggerStay:
                    {
                        return reference.OnTriggerStayAsObservable().Subscribe(action as Action<Collider>);
                        break;
                    }
            }
            return null;
        }
    }

}
