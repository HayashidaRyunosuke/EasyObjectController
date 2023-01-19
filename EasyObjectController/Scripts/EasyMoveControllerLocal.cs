using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMoveControllerLocal : ProgressController
{
    [SerializeField]
    public Vector3 defPos;

    [SerializeField]
    public Vector3 targetPos;

    public override void UpdateProgress()
    {
        transform.localPosition = Vector3.Lerp(defPos, targetPos, progress);
    }
    
    private void Reset()
    {
        defPos = targetPos = transform.localPosition;
    }
}
