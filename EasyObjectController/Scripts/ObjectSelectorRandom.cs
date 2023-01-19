using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObjectSelectorRandom : ObjectSelector
{
    
    protected override void Awake()
    {
        if (selectOnAwake) SelectRandom();
    }
    
    protected override void Reset()
    {
        base.Reset();
        SelectRandom();
    }

    public void SelectRandom()
    {
        ActivateObject(Random.Range(0,objects.Count));
    }
}
