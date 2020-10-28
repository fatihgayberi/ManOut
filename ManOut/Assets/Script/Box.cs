using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] Button boxButton;
    bool boxer;
    bool boxerRepair;
    Vector3 newPos;
    Vector3 startPos;
    public float boxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        boxButton.onClick.AddListener(TaskOnTouchBox);
        newPos = new Vector3(transform.position.x, transform.position.y, 16f);
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        HitBox();
        HitRepair();
    }

    void TaskOnTouchBox()
    {
        boxer = true;
        GetComponent<Collider>().enabled = true;
    }

    void HitBox()
    {
        if (boxer)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * boxSpeed);
            
            if (transform.position == newPos)
            {
                boxer = false;
                boxerRepair = true;
            }
        }
    }

    void HitRepair()
    {
        if (boxerRepair)
        {
            GetComponent<Collider>().enabled = false;
            
            if (transform.position == startPos)
            {
                boxerRepair = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * boxSpeed);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {    
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody>().AddForce(-transform.forward * 2500);
        }
    }
}
