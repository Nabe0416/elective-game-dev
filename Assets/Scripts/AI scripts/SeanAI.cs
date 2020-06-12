using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanAI : BaseAI
{
    public override IEnumerator RunAI()
    {
        for (int i = 0; i < 100; i++)
        {
        fire:
            if (TargetsContain(out Vector3 position, GameItems.Enemy))
            {
                Vector3 lko = (Ship.transform.position - Ship.GetComponentInChildren<LookoutCollider>().gameObject.transform.position).normalized;
                Vector3 tar = (Ship.transform.position - position).normalized;
                var angle = Vector3.Angle(lko, tar);
                Vector2 lkoV2 = new Vector2(lko.x, lko.z);
                Vector2 tarV2 = new Vector2(tar.x, tar.z);
                Debug.Log(Vector3.Cross(lkoV2, tarV2).z);
                if (Vector3.Cross(lkoV2, tarV2).z > 0)
                {
                    yield return TurnLeft(angle);
                    yield return TurnLookoutLeft(angle / 2);
                    yield return FireFront(1000);
                    yield return Ahead(10);
                }
                else if (Vector3.Cross(lkoV2, tarV2).z < 0)
                {
                    yield return TurnRight(angle);
                    yield return TurnLookoutRight(angle / 2);
                    yield return FireFront(1000);
                    yield return Ahead(10);
                }
                else
                {
                    yield return FireFront(1000);
                    yield return Ahead(10);
                }
            }
            else
                {
                for(int j = 0; j < 7; j ++)
                {
                    yield return Ahead(50);
                    if (TargetsContain(out _, GameItems.Enemy))
                        goto fire;
                }
                var rnd = Random.Range(-10, 10);
                if(rnd > 0)
                {
                    yield return TurnLeft(90);
                }
                else
                {
                    yield return TurnRight(90);
                }
            }
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
    }
}
