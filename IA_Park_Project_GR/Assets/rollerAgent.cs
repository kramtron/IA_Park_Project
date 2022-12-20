using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class rollerAgent : Agent
{ 
    Rigidbody rBody;
    public Transform Target;
    
    void Start () 
    {
        rBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
       // If the Agent fell, zero its momentum
        if (this.transform.localPosition.y < 0)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3( 0, 0.5f, 0);
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.value * 8 - 4,
                                           0.7f,
                                           Random.value * 8 - 4);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }

    public float speed = 1;
    public float rotationSpeed = 120;

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int actionValue = actionBuffers.DiscreteActions[0];

        if(actionValue == 3)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if(actionValue == 2)
        {
            transform.Rotate(transform.up * -rotationSpeed * Time.deltaTime);
        }
        else if (actionValue == 1)
        {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
        }

        float distanceToTarget = Vector3.Distance(this.transform.position, Target.localPosition);
        if(distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            EndEpisode();
        }
        // Fell off platform
        else if (this.transform.localPosition.y < 0)
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            SetReward(-0.5f);
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int value = 0;

        if(Input.GetKey(KeyCode.LeftArrow))
            value = 1;
        else if(Input.GetKey(KeyCode.RightArrow))
            value = 2;
        else if(Input.GetKey(KeyCode.UpArrow))
            value = 3; 

        var aux = actionsOut.DiscreteActions;
        aux[0] = value;
    }
}
