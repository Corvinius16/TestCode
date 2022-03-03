using InspectorAction;
using NodeEditorFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InspectorNodes
{
    [Node(false, "MoveCamera")]
    public class MoveCameraNode : Node
    {

        public const string ID = "MoveCameraNode";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "Move Camera Node"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 100); } }



        [ValueConnectionKnob("Output", Direction.Out, typeof(Flow))]
        public ValueConnectionKnob outputKnob;

        [ValueConnectionKnob("Input", Direction.In, typeof(Flow))]
        public ValueConnectionKnob inputKnob;

        [ValueConnectionKnob("Position", Direction.In, typeof(ReferenceObject))]
        public ValueConnectionKnob positionKnob;

        [ValueConnectionKnob("Look", Direction.In, typeof(ReferenceObject))]
        public ValueConnectionKnob LookKnob;


        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            inputKnob.DisplayLayout();
            outputKnob.DisplayLayout();
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            positionKnob.DisplayLayout();
            GUILayout.Space(10);
            LookKnob.DisplayLayout();
            GUILayout.EndVertical();
        }


        public override void Call(ScenarioPlayer player)
        {
            base.Call(player);

            MoveCameraAction action = new MoveCameraAction(MainManager.Instance.GetObject(player.GetNode<ReferenceObjectNode>(GetGuidNode(positionKnob)).guidObject),
                MainManager.Instance.GetObject(player.GetNode<ReferenceObjectNode>(GetGuidNode(LookKnob)).guidObject),() => player.StartAction(GetGuidNode(outputKnob)));
            StartAction(action);
        }


    }
}
