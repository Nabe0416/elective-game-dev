﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannedRobotEvent {
    public string Name;
    public float Distance; 
}

public enum GameItems
{
    Enemy,
    Pickup_HP,
    Pickup_Invin
}

public class BaseAI
{
    public PirateShipController Ship = null;

    // Events
    public virtual void OnScannedRobot(ScannedRobotEvent e)
    {
        // 
    }


    public bool TargetsContain(out Vector3 position, GameItems gi)
    {
        return Ship.__TargetsContain(out position, gi);   
    }

    public int GetHP()
    {
        return Ship.__GetHP();
    }

    public IEnumerator Ahead(float distance) {
        yield return Ship.__Ahead(distance);
    }

    public IEnumerator Back(float distance)
    {
        yield return Ship.__Back(distance);
    }

    public IEnumerator TurnLookoutLeft(float angle)
    {
        yield return Ship.__TurnLookoutLeft(angle);
    }

    public IEnumerator TurnLookoutRight(float angle)
    {
        yield return Ship.__TurnLookoutRight(angle);
    }

    public IEnumerator TurnLeft(float angle)
    {
        yield return Ship.__TurnLeft(angle);
    }

    public IEnumerator TurnRight(float angle)
    {
        yield return Ship.__TurnRight(angle);
    }

    public IEnumerator FireFront(float power)
    {
        yield return Ship.__FireFront(power);
    }

    public IEnumerator FireLeft(float power)
    {
        yield return Ship.__FireLeft(power);
    }

    public IEnumerator FireRight(float power)
    {
        yield return Ship.__FireRight(power);
    }

    public virtual IEnumerator RunAI()
    {
        yield return null;
    }

    public static implicit operator string(BaseAI v)
    {
        throw new NotImplementedException();
    }
}