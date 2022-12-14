using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePath : MonoBehaviour
{
    Vector3 target;
    Vector3 dir;
    Vector3 mov;
    Vector3 newVec;

    [SerializeField] float vel = 0;
    private float freq = 0f;
    public float freqAct;

    public float angle;
    public float turnSpeed;

    private float posAct;
    [SerializeField] float posActTime;

    private Quaternion rotation;
    
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > freqAct)
        {
            freq -= freqAct;
            Seek();
        }

        posAct += Time.deltaTime;

        if (posAct > posActTime)
        {
            posAct -= posActTime;
            TargetPositionChanger();
        }
        MoveToTarget();
    }

    private void TargetPositionChanger()
    {
        target = newVec = new Vector3(UnityEngine.Random.Range(20, -20), 0, UnityEngine.Random.Range(20, -20));
    }

    private void MoveToTarget()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * vel * Time.deltaTime;
    }

    private void Seek()
    {
        dir = target - transform.position;
        dir.y = 0;
        mov = dir.normalized * vel;
        angle = Mathf.Rad2Deg * Mathf.Atan2(mov.x, mov.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
