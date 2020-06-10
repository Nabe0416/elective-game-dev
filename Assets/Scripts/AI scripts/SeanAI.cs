using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanAI : BaseAI
{
    public override IEnumerator RunAI()
    {
        for(int i = 0; i < 100; i++)
        {
            if (TargetsContain(out Vector3 position, GameItems.Enemy))
            {
                Vector3 lko = (Ship.transform.position - Ship.GetComponentInChildren<LookoutCollider>().gameObject.transform.position).normalized;
                Vector3 tar = (Ship.transform.position - position).normalized;
                var angle = Vector3.Angle(lko, tar);
                if (Vector3.Cross(lko, tar).z < 0)
                {
                    yield return TurnLeft(angle);
                    yield return TurnLookoutLeft(angle);
                    yield return FireFront(1000);
                    yield return Ahead(10);
                }
                else
                {
                    yield return TurnRight(angle);
                    yield return TurnLookoutRight(angle);
                    yield return FireFront(1000);
                    yield return Ahead(10);
                }
            }
            else
            {
                yield return Ahead(25);
            }
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
    }
}
