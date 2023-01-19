using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressController : MonoBehaviour
{

    [SerializeField,Range(0f,1f)]
    protected float progress = 0f;

    public float playDuration = 1f;

    public float playDelay = 0f;
    
    public bool playOnAwake = false;
    
    public bool isPlaying = false;

    public UnityEvent onPlayBegun = new UnityEvent();

    public UnityEvent onPlayEnded = new UnityEvent();
    
    private Coroutine playCoroutine;

    void Awake()
    {
       if (playOnAwake) Play();
    }

    public void Init()
    {
        progress = 0f;
        UpdateProgress();
    }
    
    public void Play()
    {
        if (isPlaying) return;
        if (playCoroutine != null) StopCoroutine(playCoroutine);
        playCoroutine = StartCoroutine(PlayCoroutine());
    }

    public void Reverse()
    {
        if (isPlaying) return;
        if (playCoroutine != null) StopCoroutine(playCoroutine);
        playCoroutine = StartCoroutine(ReverseCoroutine());
    }
    
    private IEnumerator PlayCoroutine()
    {
        onPlayBegun?.Invoke();
        isPlaying = true;
        progress = 0f;
        SetProgress(progress);

        yield return new WaitForSeconds(playDelay);
        
        while (true)
        {
            SetProgress(progress);
            if (progress >= 1f) break;
            progress += Time.deltaTime / playDuration;
            yield return null;
        }
        isPlaying = false;
        onPlayEnded?.Invoke();
    }

    private IEnumerator ReverseCoroutine()
    {
        onPlayBegun?.Invoke();
        isPlaying = true;
        progress = 1f;
        SetProgress(progress);

        yield return new WaitForSeconds(playDelay);
        
        while (true)
        {
            SetProgress(progress);
            if (progress <= 0f) break;
            progress -= Time.deltaTime / playDuration;
            yield return null;
        }
        isPlaying = false;
        onPlayEnded?.Invoke();
    }
    
    public virtual void SetProgress(float p)
    {
        progress = p;
        if (progress > 1f) progress = 1f;
        if (progress < 0f) progress = 0f;
        UpdateProgress();
    }

    /// <summary>
    /// 継承して使用
    /// </summary>
    public virtual void UpdateProgress() {}
    
    void OnValidate()
    {
        SetProgress(progress);
    }
}
