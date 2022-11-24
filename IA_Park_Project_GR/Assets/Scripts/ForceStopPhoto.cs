using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;


namespace BBUnity.Actions
{

    [Action("Navigation/ForceStopPhoto")]

    public class ForceStopPhoto : GOAction
    {

        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
           if(gameObject.GetComponentInChildren<Light>().intensity == 10)
            {
                gameObject.GetComponentInChildren<Light>().intensity = 0;
                return TaskStatus.COMPLETED;
            }
           else
            {
                return TaskStatus.COMPLETED;

            }

        }
    }

}
