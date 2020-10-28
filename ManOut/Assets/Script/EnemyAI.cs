using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour
{
    Vector3 targetPos;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = RandNewPos();
    }

    void FixedUpdate()
    {
        Walk();
    }

    Vector3 RandNewPos()
    {
        float newX = Random.Range(-9f, 9f);
        float newZ = Random.Range(8.75f, 17f);

        return new Vector3(newX, transform.position.y, newZ);
    }

    void Walk()
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * enemySpeed);
        }
        else
        {
            targetPos = RandNewPos();
        }
    }
}
