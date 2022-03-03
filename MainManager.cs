using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public List<ReferenceObject> objects = new List<ReferenceObject>();

    public Material Outline1;
    public Material Outline2;

    public Camera mainCamera;

    public ScenarioPlayer Scenario;

    public GameObject Lamp;

    public Image perecentLook;

    public VRTK.VRTK_ControllerEvents leftHand;

    public Camera LookObjectCam;

    public GameObject CanvasRender;

    public GameObject InspectorModel;

    private  bool isPlay = false;

 
    public static MainManager Instance;

    public ReferenceObject GetObject(MyGuid guid)
    {
        return objects.Find((x) => x.Guid == guid);
    }


    public void Awake()
    {
        isPlay = true;
        Instance = this;
        leftHand.ControllerModelAvailable += LeftHand_ControllerModelAvailable;
    }

    private void LeftHand_ControllerModelAvailable(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        Scenario.StartScenario();
    }



    public void OnDisable()
    {
        isPlay = false;
    }

}
