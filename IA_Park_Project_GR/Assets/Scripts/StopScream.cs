using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;




namespace BBUnity.Actions
{

    [Action("Navigation/StopScream")]


    public class StopScream : GOAction
    {
        [InParam("target")]
        [Help("Target game object towards this game object will be moved")]
        public GameObject target;

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {

            target.GetComponent<CBVariables>().stealed = false;
            return TaskStatus.COMPLETED;

        }
    }
}
