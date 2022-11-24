using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;


namespace BBUnity.Actions
{

    [Action("Navigation/DoPhoto")]

    public class DoPhoto : GOAction
    {

        float temp = 0;
        float timebwPh = 0;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {

            if (timebwPh >= 1)
            {
                temp += Time.deltaTime;

                if (temp < 1.0f)
                {
                    gameObject.GetComponentInChildren<Light>().intensity = 10;

                    return TaskStatus.RUNNING;

                }

                else if (temp > 1.0f)
                {
                    gameObject.GetComponentInChildren<Light>().intensity = 0;
                    temp = 0;
                    timebwPh = 0;

                    return TaskStatus.COMPLETED;


                }
                else
                {
                    return TaskStatus.RUNNING;
                }
            }
            else if (timebwPh < 1)
            {
                timebwPh += Time.deltaTime;
                return TaskStatus.RUNNING;

            }

            else
            {
                return TaskStatus.RUNNING;

            }

        }
    }

}
