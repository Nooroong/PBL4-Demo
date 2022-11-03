using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_F : MonoBehaviour
{
	public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) //오디오 페이드 아웃
	{
		float startVolume = audioSource.volume;
		while (audioSource.volume > 0)
		{
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.Stop();
	}

	public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime) //오디오 페이드 인
	{
		audioSource.Play();
		audioSource.volume = 0f;
		while (audioSource.volume < 1)
		{
			audioSource.volume += Time.deltaTime / FadeTime;
			yield return null;
		}
	}
}
