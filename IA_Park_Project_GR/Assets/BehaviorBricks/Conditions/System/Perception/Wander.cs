using Pada1.BBCore;
using UnityEngine;


namespace BBUnity.Conditions
{

    [Condition("Perception/Wander")]

    public class Wander : GOCondition
    {

        [InParam("target")]
        [Help("Target to check the distance")]
        public GameObject police;


        [InParam("closeDistance")]
        [Help("The maximun distance to consider that the target is close")]
        public float closeDistance;


        public override bool Check()
        {

            return  Vector3.Distance(gameObject.transform.position, police.transform.position) < closeDistance;

        }

    }

}
