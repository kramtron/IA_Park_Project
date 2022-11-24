using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;




namespace BBUnity.Actions
{

    [Action("Navigation/ActivateScream")]


    public class Scream : GOAction
    {
        [InParam("target")]
        [Help("Target game object towards this game object will be moved")]
        public GameObject target;

        public override TaskStatus OnUpdate()
        {

            target.GetComponent<CBVariables>().stealed = true;
            return TaskStatus.COMPLETED;

        }
    }
}