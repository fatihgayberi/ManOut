using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Button trampolineButton;
    Vector3 startPos;
    Vector3 endPos;
    bool jumpController;
    public float trampolineSpeed;

    // Start is called before the first frame update
    void Start()
    {
        trampolineButton.onClick.AddListener(TaskOnTouchTrampoline);
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, 1f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void TaskOnTouchTrampoline()
    {
        //gameObject.transform.GetChild(0).GetComponent<Collider>().isTrigger = true;
        //jumpController = true;
    }

    void Jump()
    {
        if (jumpController)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * trampolineSpeed);
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
