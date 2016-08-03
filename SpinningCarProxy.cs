using System;
using UnityEngine;

public class SpinningCarProxy : SpinningCar
{
    protected override void Awake ()
    {
        carRotationAxis = transform.Find ("rotator");
        frontAxis = transform.Find ("frontAxis");
        backAxis = transform.Find ("backAxis");
        base.Awake ();
    }
        
}
