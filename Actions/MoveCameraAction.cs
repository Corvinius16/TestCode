using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InspectorAction
{
    public class MoveCameraAction :AbstractAction
    {
        ReferenceObject position;
        ReferenceObject look;

        Transform MainCamera;

        public MoveCameraAction(ReferenceObject position, ReferenceObject look, Action completeAction) : base( completeAction)
        {
            this.position = position;
            this.look = look;
        
        }

        public override void Call()
        {
            MainCamera = MainManager.Instance.mainCamera.transform;
            StartCoroutine(Move());       
            completeAction();
        }

        IEnumerator Move()
        {
            while (Vector3.Distance(MainCamera.position, position.transform.position) > 0.1f)
            {
              Vector3 relativePos = look.transform.position - MainCamera.transform.position;

                Debug.Log("Move");
              
        // the second argument, upwards, defaults to Vector3.up
                  Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                // MainCamera rotate towards the target point.
                MainCamera.rotation = Quaternion.RotateTowards(MainCamera.rotation, rotation, Time.deltaTime*150);
                MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, position.transform.position, Time.deltaTime*3);
                yield return null;
            }
        }

    }
}
