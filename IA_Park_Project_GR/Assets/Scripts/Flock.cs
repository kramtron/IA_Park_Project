using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FloackManager myManager;

    public Vector3 direction;

    float speed = 2;

    private float freq = 0f;
    public float freqAct;

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
            direction = (Cohesion() + Align() + Separation() + (FolowLid() * 5)).normalized * speed;
        }

        transform.rotation =    Quaternion.Slerp(transform.rotation,
                                Quaternion.LookRotation(direction),
                                myManager.RotationSpeed * Time.deltaTime);

        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    Vector3 Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;

        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.NeighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }

        if (num > 0)
        {
            return (cohesion / num - transform.position).normalized;
        }

        if (num == 0)
        {
            foreach (GameObject go in myManager.allFish)
            {
                if (go != this.gameObject)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        return (cohesion / num - transform.position).normalized;
    }

    Vector3 Align()
    {
        Vector3 align = Vector3.zero;

        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.NeighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.MinSpeed, myManager.MaxSpeed);
        }

        return align;
    }

    Vector3 Separation()
    {
        Vector3 separation = Vector3.zero;

        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if (distance <= myManager.NeighbourDistance)
                    separation -= (transform.position - go.transform.position)/(distance * distance);
            }
        }

        return separation;
    }

    Vector3 FolowLid()
    {
        return ((myManager.Leader.transform.position - transform.position).normalized);
    }
}
