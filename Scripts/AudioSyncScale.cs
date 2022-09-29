using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
    public Vector3 beatScale;
    public Vector3 restScale;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        transform.localScale = Vector3.Lerp(transform.localScale,
            restScale, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }

    private IEnumerator MoveToScale(Vector3 _target)
    {
        Vector3 _curr = transform.localScale;
        Vector3 _initial = _curr;
        float _timer = 1;

        while (_curr != _target)
        {
            _curr = Vector3.Lerp(_initial, _target, _timer / timeToBeat);

            transform.localScale = _curr;

            yield return null;
        }

        m_isBeat = false;
    }

    public void SetBias(float b)
    {
        bias = b;
    }

    public void SetTimeStep(float ts)
    {
        timeStep = ts;
    }

    public void SetTimeBeat(float tb)
    {
        timeToBeat = tb;
    }

    public void SetRestTime(float rt)
    {
        restSmoothTime = rt;
    }

    public void SetScale(float s)
    {
        beatScale.y = s;
    }

    public float GetScale()
    {
        return beatScale.y;
    }
}
