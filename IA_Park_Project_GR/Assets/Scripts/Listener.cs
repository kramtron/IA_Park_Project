using Pada1.BBCore;
using UnityEngine;




namespace BBUnity.Conditions
{


    [Condition("Perception/IsScreaming")]

    public class Listener : GOCondition
    {

        [InParam("target")]
        [Help("Target game object towards this game object will be moved")]
        public GameObject CB;


        // Start is called before the first frame update
        public override bool Check()
        {


            return CB.GetComponent<CBVariables>().stealed;
        }

    }
}
