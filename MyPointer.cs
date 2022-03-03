using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPointer : VRTK.VRTK_Pointer
{
    protected override void ExecuteSelectionButtonAction()
    {
        //  base.ExecuteSelectionButtonAction();
        if (EnabledPointerRenderer() && CanSelect() && (IsPointerActive() || wasActivated))
        {

            wasActivated = false;
            RaycastHit pointerRendererDestinationHit = pointerRenderer.GetDestinationHit();
            Vector3 pos = (pointerRenderer as Teleporter).TargetPos;
            AttemptUseOnSet(pointerRendererDestinationHit.transform);
            if (pointerRendererDestinationHit.transform && IsPointerActive() && pointerRenderer.ValidPlayArea() && !PointerActivatesUseAction(pointerInteractableObject))
            {

                ResetHoverSelectionTimer(pointerRendererDestinationHit.collider);
                ResetSelectionTimer();
                OnDestinationMarkerSet(SetDestinationMarkerEvent(pointerRendererDestinationHit.distance, pointerRendererDestinationHit.transform, pointerRendererDestinationHit, pos, controllerReference, false, GetCursorRotation()));
            }
        }
    }
}
