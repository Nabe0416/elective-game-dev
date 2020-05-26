using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexAI : BaseAI
{
    private GameObject HealthBar;
    private GameObject Name;

    public override IEnumerator RunAI()
    {
        while (true)
        {
            yield return Ahead(300);
            yield return TurnRight(180);
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
    }
}
