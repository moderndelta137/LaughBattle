using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioRecorder_v1 : MonoBehaviour
{
	public Slider[] slider;

	private AudioClip recording;
	private AudioSource[] audioSources;
	private AudioSource audioSource;

	private float _volume, _freq;
	public float volume, freq, lerpRate;
	public int lengthInSeconds = 10;
	public bool isRecording = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		//audioSources[0].clip = Microphone.Start(null, true, 10, 44100);
		//audioSources[0].loop = true;
		//while (!(Microphone.GetPosition(null) > 0)) { }
		//audioSources[0].Play();
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

	public void StartRecording()
	{
		if (isRecording)
			return;

		isRecording = true;
		recording = Microphone.Start(null, false, lengthInSeconds, 44100);
		Debug.Log("Start Recording");

		Invoke("StopRecording", lengthInSeconds);
	}
	public void StopRecording()
	{
		isRecording = false;
		Microphone.End(null);
		Debug.Log("Stop Recording");
	}

	public void PlayRecording()
	{
		audioSource.clip = recording;
		audioSource.Play();
		Debug.Log("Play Recording");
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
