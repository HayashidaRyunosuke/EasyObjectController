using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyScaleController : ProgressController
{

    [SerializeField]
    public float defScale;

    [SerializeField]
    public float targetScale;
    
    public override void UpdateProgress()
    {
        float scale = Mathf.Lerp(defScale, targetScale, progress);
        transform.localScale = Vector3.one * scale;   
    }

    private void Reset()
    {
        defScale = targetScale = transform.localScale.x;
    }
}
