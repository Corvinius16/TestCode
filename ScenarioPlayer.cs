using NodeEditorFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InspectorNodes;
using UniRx;
public class ScenarioPlayer : MonoBehaviour {

    public NodeCanvas NodeCanvas;

    private Dictionary<MyGuid, Node> nodes = new Dictionary<MyGuid, Node>();

    private MyGuid idNode;

    public Action CompleteAction;

    public bool isStartScenario;


   
    public void StartScenario()
    {
        if (!isStartScenario)
        {
            isStartScenario = true;
            var s = Observable.Start(() =>
            {
                InitNodes();
                StartAction(idNode);
            });
            Observable.WhenAll(s)
            .ObserveOnMainThread() // return to main thread
            .Subscribe(xs =>
                {
              Debug.Log("Start Scenario");
              });
        }

    }

    public void StartAction(MyGuid id)
    {
        var s = Observable.Start(() =>
        {
            nodes[id].Call(this);
        });
        Observable.WhenAll(s).ObserveOnMainThread().Subscribe((x) =>
        {
        });
    }

    public T GetNode<T>(MyGuid id) where T:Node
    {
        return (T)nodes[id];
    }
  
    private void InitNodes()
    {
        foreach (var item in NodeCanvas.nodes)
        {
            nodes.Add(item.IdNode, item);

            if (item is StartNode)
            {
                idNode = item.IdNode;
            }
        }
    }
}
