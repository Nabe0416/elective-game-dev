using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IljaAI : BaseAI
{
    private int RandomNumber = 0;
    public override IEnumerator RunAI()
    {
        /*        for (int i = 0; i < 10; i++)
                {
                    yield return Ahead(200);
                    yield return FireFront(1);
                    yield return TurnLookoutLeft(90);
                    yield return TurnLeft(360);
                    yield return FireLeft(1);
                    yield return TurnLookoutRight(180);
                    yield return Back(200);
                    yield return FireRight(1);
                    yield return TurnLookoutLeft(90);
                    yield return TurnRight(90);
                }
            }
            */
        {
            while (true)
            {
                #region MoveModes
                if (RandomNumber == 0)
                {
                    yield return Ahead(100);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 1)
                {
                    yield return TurnLeft(180);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 2)
                {
                    yield return TurnRight(300);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 3)
                {
                    yield return Ahead(0);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 4)
                {
                    yield return Ahead(50);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 5)
                {
                    yield return Ahead(20);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 6)
                {
                    yield return Ahead(15);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 7)
                {
                    yield return Ahead(60);
                    RandomNumber = Random.Range(0, 10);
                }
                #endregion


                #region FireModes
                if (RandomNumber == 8)
                {
                    yield return FireFront(1);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 9)
                {
                    yield return FireLeft(1);
                    RandomNumber = Random.Range(0, 10);
                }
                if (RandomNumber == 10)
                {
                    yield return FireRight(1);
                    RandomNumber = Random.Range(0, 10);
                }
                #endregion
            }
        }
    }
    public override void OnScannedRobot(ScannedRobotEvent e)
    {
        //Debug.Log("Ship detected: " + e.Name + " at distance: " + e.Distance);
    }
}
