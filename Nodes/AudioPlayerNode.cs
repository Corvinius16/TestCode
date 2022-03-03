using UnityEngine;
using NodeEditorFramework;
using InspectorAction;

namespace InspectorNodes
{
    [Node(false, "AudioPlayer")]
    public class AudioPlayerNode : Node
    {
        public const string ID = "AudioPlayerNode";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "AudioPlayer Node"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 90); } }


        [ValueConnectionKnob("Output", Direction.Out, typeof(Flow))]
        public ValueConnectionKnob outKnob;

        [ValueConnectionKnob("Input", Direction.In, typeof(Flow))]
        public ValueConnectionKnob inputKnob;

        [ValueConnectionKnob("Audio", Direction.In, typeof(AudioClip))]
        public ValueConnectionKnob audioKnob;

        public bool wait;

        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            inputKnob.DisplayLayout();
            outKnob.DisplayLayout();
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            audioKnob.DisplayLayout();
            GUILayout.Space(10);
            wait = GUILayout.Toggle(wait, "isWait");
            GUILayout.EndVertical();
        }

        public override void Call(ScenarioPlayer player)
        {
            base.Call(player);

            PlayAudioAction action = new PlayAudioAction(player.GetNode<SoundNode>(GetGuidNode(audioKnob)).clip, () => player.StartAction(GetGuidNode(outKnob)),wait);
            StartAction(action);
        }
    }
}
