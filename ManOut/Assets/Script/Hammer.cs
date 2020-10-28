using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
    [SerializeField] Button hammerButton;
    Quaternion rotation1;
    Quaternion rotation2;
    bool hammerControl;
    bool hammerRepair;
    float hitTimeCount;
    float repairTimeCount;

    // Start is called before the first frame update
    void Start()
    {
        hammerButton.onClick.AddListener(TaskOnTouchHammer);
        rotation1 = Quaternion.Euler(-180, 0, 0);
        rotation2 = Quaternion.Euler(-360, 0, 0);
    }

    private void FixedUpdate()
    {
        HammerHit();
        HammerRepair();
    }

    void TaskOnTouchHammer()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        hammerControl = true;
    }

    void HammerHit()
    {
        if (hammerControl)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation1, hitTimeCount);
            hitTimeCount += Time.deltaTime;
            if (transform.rotation.eulerAngles == rotation1.eulerAngles)
            {
                hammerControl = false;
                hammerRepair = true;
                hitTimeCount = 0;
            }
        }
    }

    void HammerRepair()
    {
        if (hammerRepair)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation2, repairTimeCount);
            repairTimeCount += Time.deltaTime;
            if (transform.rotation.eulerAngles == rotation2.eulerAngles)
            {
                hammerRepair = false;
                repairTimeCount = 0;
            }
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
