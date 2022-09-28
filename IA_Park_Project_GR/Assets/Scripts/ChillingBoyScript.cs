using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillingBoyScript : MonoBehaviour
{

    [SerializeField] GameObject target;


    Vector3 dir;
    Vector3 mov;
    [SerializeField] float vel = 0;
    private float freq = 0f;
    public float freqAct;
    public float turnAcc = 2;
    public float acc = 2;
    public float maxTurnSpeed = 15;
    public float walkingSpeed = 5;

    public float minSpeed = 0;

    public float angle;
    public float turnSpeed;
    private Quaternion rotation;

    public float stopDistance;

    Vector3 newVec;

    private float posAct;
    private float posActTime;
    private bool near = false;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > freqAct)
        {
            freq -= freqAct;
            Seek();

        }

        
        
        if (near)
        {
            posAct += Time.deltaTime;

            posActTime = Random.Range(5, 20);

            if (posAct > posActTime)
            {
                posAct = 0;
                TargetPositionChanger();

            }
        }

        if (Vector3.Distance(target.transform.position, transform.position) <= stopDistance)
        {
            near = true;
            SlowToTarget();
        }
        else
        {
            near = false;
            MoveToTarget();
        }
    }
    private void TargetPositionChanger()
    {

         target.transform.position = newVec = new Vector3(UnityEngine.Random.Range(20, -20), 0, UnityEngine.Random.Range(20, -20));
    }


    private void MoveToTarget()
    {
        turnSpeed += turnAcc * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        vel += acc * Time.deltaTime;
        vel = Mathf.Max(vel, walkingSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * vel * Time.deltaTime;
    }

    private void SlowToTarget()
    {
        turnSpeed += turnAcc * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        vel -= acc / Time.deltaTime;
        vel = Mathf.Max(vel, minSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * vel * Time.deltaTime;
    }

    private void Seek()
    {
        dir = target.transform.position - transform.position;
        dir.y = 0;
        mov = dir.normalized * vel;
        angle = Mathf.Rad2Deg * Mathf.Atan2(mov.x, mov.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);

    }
}
