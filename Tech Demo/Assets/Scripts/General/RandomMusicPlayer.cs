using System.Collections;
using UnityEngine;

namespace PatataStudio.General
{
	public class RandomMusicPlayer : MonoBehaviour
	{
		[SerializeField] private AudioClip[] audioClips;
		private AudioSource musicAudioSource;
		private int randomClip;
		private int lastPlayedClip;

		private void Awake()
		{
			musicAudioSource = GetComponent<AudioSource>();
		}

		private void Start()
		{
			StartCoroutine(PlayMusic());
		}

		private IEnumerator PlayMusic()
		{
			randomClip = Random.Range(0, audioClips.Length);
			if(randomClip == lastPlayedClip) randomClip = randomClip + 1 < audioClips.Length ? randomClip + 1 : randomClip - 1;
			lastPlayedClip = randomClip;
			musicAudioSource.clip = audioClips[randomClip];
			musicAudioSource.PlayOneShot(musicAudioSource.clip);
			yield return new WaitForSeconds(musicAudioSource.clip.length);
			StartCoroutine(PlayMusic());
		}
	}
}