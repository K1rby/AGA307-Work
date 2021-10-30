using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scavanger : Enemies
{
    public float scavangerRange;

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
