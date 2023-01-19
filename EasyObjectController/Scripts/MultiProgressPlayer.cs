using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiProgressPlayer : ProgressController
{

    [SerializeField]
    public List<ProgressController> progressControllers = new List<ProgressController>();

    public override void UpdateProgress()
    {
        for (int i = 0;i<progressControllers.Count;i++)
        {
            progressControllers[i].SetProgress(progress);
        }
    }
}
