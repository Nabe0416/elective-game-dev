using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanAI : BaseAI
{
    public override IEnumerator RunAI()
    {
        for(int i = 0; i < 20; i++)
        {
            yield return Ahead(100);
            if (TargetsContain(out Vector3 position, GameItems.Enemy))
            {
                float angle = Vector3.Angle(Ship.transform.position, position);
                Debug.Log("Found enemy at " + position + " turn " + angle);
                if (angle > 5)
                {
                    TurnLeft(5);
                    if (Vector3.Angle(Ship.transform.position, position) > angle)
                    {
                        goto turnRight;
                    }
                    else
                    {
                        goto turnLeft;
                    }
                }
            turnRight:
                {
                    while (angle > 10)
                    {
                        TurnRight(5);
                        angle = Vector3.Angle(Ship.transform.position, position);
                    }
                }
            turnLeft:
                {
                    while (angle > 10)
                    {
                        TurnLeft(5);
                        angle = Vector3.Angle(Ship.transform.position, position);
                    }
                }
            }
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
    }
}
