using UnityEngine;
using NodeEditorFramework;
using InspectorAction;

namespace InspectorNodes
{
    [Node(false, "AnimationModel")]
    public class AnimationModelNode : Node
    {
        public const string ID = "AnimationModelNode";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "AnimationModel Node"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 90); } }


        [ValueConnectionKnob("Output", Direction.Out, typeof(Flow))]
        public ValueConnectionKnob outKnob;

        [ValueConnectionKnob("Input", Direction.In, typeof(Flow))]
        public ValueConnectionKnob inputKnob;

 
        public string trigger;
        public bool wait;



        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            inputKnob.DisplayLayout();
            outKnob.DisplayLayout();
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            wait = GUILayout.Toggle(wait, "isWait");
            GUILayout.Space(10);
            trigger = GUILayout.TextField(trigger);
            GUILayout.EndVertical();
        }

        public override void Call(ScenarioPlayer player)
        {
            base.Call(player);
            AnimationModelAction action = new AnimationModelAction(trigger, wait, () => player.StartAction(GetGuidNode(outKnob)));
            StartAction(action);
        }
    }
}
