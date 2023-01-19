using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{

    [SerializeField]
    protected List<GameObject> objects = new List<GameObject>();
    
    public int targetIndex = 0;
    
    private int curObjIndex = 0;

    public bool selectOnAwake = false;

    protected virtual void Awake()
    {
        if (selectOnAwake) ActivateObject(targetIndex);
    }

    public void ActivateNextObject()
    {
        int targetIndex = curObjIndex + 1;
        if (targetIndex >= objects.Count) targetIndex = 0;
        if (targetIndex < 0) targetIndex = objects.Count - 1;
        ActivateObject(targetIndex);
    }
    
    public void ActivateObject(int index)
    {
        if (objects.Count == 0) return;
        if (index >= objects.Count) index = objects.Count - 1;
        if (index < 0) index = 0;
        
        for (int i = 0;i<objects.Count;i++) objects[i].SetActive(i==index);
        curObjIndex = index;
    }
    
    public void SetActiveAll(bool active)
    {
        foreach (var obj in objects) obj.SetActive(active);
    }
    
    protected virtual void Reset()
    {
        foreach (Transform child in transform)
        {
            objects.Add(child.gameObject);
        }

        ActivateObject(0);
    }
    
}
