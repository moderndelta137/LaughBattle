using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioRecorder_v0 : MonoBehaviour
{
	public Slider[] slider;

	private AudioSource audioSource;

	private float _volume, _freq;
	public float volume, freq, lerpRate;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = Microphone.Start(null, true, 10, 44100);
		audioSource.loop = true;
		while (!(Microphone.GetPosition(null) > 0)) { }
		audioSource.Play();
	}

	void Update()
	{
		GetVolume();
		GetSpectrum();

		if (slider[0] == null)
			return;

		slider[0].value = volume;
		slider[1].value = freq;
	}



	public void GetVolume()
	{
		float[] samples = new float[1024];
		audioSource.GetOutputData(samples, 0);
		_volume = GetRMSVolume(samples);

		volume = _volume * 2;
	}

	float GetRMSVolume(float[] samples)
	{
		float sum = 0;
		foreach (float sample in samples)
		{
			sum += sample * sample;
		}
		return Mathf.Sqrt(sum / samples.Length);
	}

	public void GetSpectrum()
	{
		float[] spectrum = new float[1024];
		audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

		var maxIndex = 0;
		var maxValue = 0.0f;
		for (int i = 0; i < spectrum.Length; i++)
		{
			var val = spectrum[i];
			if (val > maxValue)
			{
				maxValue = val;
				maxIndex = i;
			}
		}

		var ___freq = (float)maxIndex * AudioSettings.outputSampleRate / 2 / spectrum.Length;

		var __freq = ___freq.Map(80f, 2500f, 0f, 1f);
		_freq = Mathf.Lerp(_freq, __freq, lerpRate);
		freq = Mathf.Clamp(_freq, 0f, 1f);
	}
}
