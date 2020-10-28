using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pit : MonoBehaviour
{
    [SerializeField] Button pitButton;
    Quaternion startRotation;
    Quaternion endRotation;
    bool pitControl;
    bool pitRepair;
    float pitTimeCount;
    float repairTimeCount;
    float wait;

    // Start is called before the first frame update
    void Start()
    {
        pitButton.onClick.AddListener(TaskOnTouchPit);
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(0, 0, 90);
    }

    private void FixedUpdate()
    {
        PitController();
        PitRepair();
    }

    void TaskOnTouchPit()
    {
        pitControl = true;
    }

    void PitController()
    {
        if (pitControl)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, pitTimeCount);
            pitTimeCount += Time.deltaTime;

            if (transform.rotation == endRotation)
            {
                pitControl = false;
                pitRepair = true;
                pitTimeCount = 0f;
            }
        }
    }

    void PitRepair()
    {
        if (pitRepair && RepairWait())
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, repairTimeCount);
            repairTimeCount += Time.deltaTime;

            if (transform.rotation == startRotation)
            {
                pitRepair = false;
                wait = 0;
                repairTimeCount = 0f;
            }
        }
    }

    bool RepairWait()
    {
        wait += Time.deltaTime;

        if (wait >= 1)
        {
            return true;
        }

        return false;
    }
}
