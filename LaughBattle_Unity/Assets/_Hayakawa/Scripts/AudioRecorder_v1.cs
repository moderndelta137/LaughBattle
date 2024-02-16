using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioRecorder_v1 : MonoBehaviour
{
	public Slider[] slider;

	private AudioClip recording;
	private AudioSource audioSource;

	private float _volume, _freq, startTime;
	public float volume, freq, count, _count, lerpRate;
	public int lengthInSeconds = 15;
	private bool isCount;
	public bool isPlaying = false, isRecording = false , finished_recording = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		//audioSources[0].clip = Microphone.Start(null, true, 10, 44100);
		//audioSources[0].loop = true;
		//while (!(Microphone.GetPosition(null) > 0)) { }
		//audioSources[0].Play();
	}

	void OnEnable()
	{
		isPlaying=false;
		isRecording=false;
		finished_recording=false;
	}

	void Update()
	{
		GetVolume();
		GetSpectrum();
		GetCount();
		GetPlaying();

		if (slider[0] == null)
			return;

		slider[0].value = volume;
		slider[1].value = freq;
		slider[2].value = count;
	}

	public void StartRecording()
	{
		if (isRecording)
			return;

		isRecording = true;
		StartCount();
		recording = Microphone.Start(null, false, lengthInSeconds, 44100);
		Debug.Log("Start Recording");

		Invoke("StopRecording", lengthInSeconds);
	}
	public void StopRecording()
	{
		finished_recording = true;
        isRecording = false;
		isCount = false;
		Microphone.End(null);
		Debug.Log("Stop Recording");
	}

	public void PlayRecording()
	{
		StartCount();
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

		var __freq = ___freq.Map(500f, 3000f, 0f, 1f);
		_freq = Mathf.Lerp(_freq, __freq, lerpRate);
		freq = Mathf.Clamp(_freq, 0f, 1f);
	}

	public void GetCount()
	{
		if (!isCount)
			return;

		_count = Time.time - startTime;
		count = _count.Map(0f, lengthInSeconds, 0f, 1f);
	}

	public void StartCount()
	{
		startTime = Time.time;
		isCount = true;
	}

	public void GetPlaying()
	{
		if (!audioSource.isPlaying && isPlaying)
		{
			isCount = false;
			Debug.Log("End Playing");
		}

		isPlaying = audioSource.isPlaying;
	}

	public void ResetRecordingStatus()
	{
		isPlaying = false;
		isRecording = false;
		finished_recording = false;
		count = 0;
		_count = 0;
	}
}
