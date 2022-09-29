using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioSyncColor : AudioSyncer
{

	public Color[] beatColors;
	public Color restColor;

	private int randomIndex;
	private Material mat;

	private IEnumerator MoveToColor(Color _target)
	{
		Color _curr = mat.color;
		Color _initial = _curr;
		float _timer = 0;

		while (_curr != _target)
		{
			_curr = Color.Lerp(_initial, _target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			mat.color = _curr;
			mat.SetColor("_EmissionColor", _curr);

			yield return null;
		}

		m_isBeat = false;
	}

	private Color RandomColor()
	{
		if (beatColors == null || beatColors.Length == 0) return Color.white;
		randomIndex = Random.Range(0, beatColors.Length);
		return beatColors[randomIndex];
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;

		mat.color = Color.Lerp(mat.color, restColor, restSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();

		Color _c = RandomColor();

		StopCoroutine("MoveToColor");
		StartCoroutine("MoveToColor", _c);
	}

	private void Start()
	{
		if (tag == "Car") mat = GetComponent<Renderer>().materials[2];
		else mat = GetComponent<Renderer>().material;
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

	public void SetColor(Color color)
    {
		this.beatColors[0] = color;
    }

	public void SetRestColor(Color color)
    {
		this.restColor = color;
    }
}
