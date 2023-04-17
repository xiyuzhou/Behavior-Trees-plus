using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToBox : Node
{
    private Transform _transform;
    private Transform Box;

    public TaskGoToBox(Transform transform, Transform box)
    {
        _transform = transform;
        Box = box;
        
    }

    public override NodeState Evaluate()
    {

        if (Vector3.Distance(_transform.position, Box.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, Box.position, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(Box.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
