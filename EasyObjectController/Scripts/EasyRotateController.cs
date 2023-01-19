using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyRotateController : ProgressController
{
    
    [SerializeField]
    public Vector3 defRot;
    
    [SerializeField]
    public Vector3 targetRot;
    
    public override void UpdateProgress()
    {
        transform.rotation = Quaternion.Euler(Vector3.Lerp(defRot,targetRot,progress));
    }

    void Reset()
    {
        defRot = targetRot = transform.rotation.eulerAngles;
    }
    
}
