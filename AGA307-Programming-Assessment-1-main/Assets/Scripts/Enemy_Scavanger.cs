using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scavanger : Enemies
{
    public float scavangerRange;

    //Each override void inherits the commands from the Enemies script
    public override void SetUp()
    {
        base.SetUp();
    }

    protected override void SeekTarget()
    {
        base.SeekTarget();
    }

    public override void Die()
    {
        base.Die();
    }
}
