using DesignPatterns.StateMachines;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class IdleState : State
{
    public IdleState() : base(() => { Debug.Log("sad"); }, "IdleState", false)
    {
    }
}
