using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PatataStudio.Menu
{
	public class OptionsMenu : MonoBehaviour
	{
		[Header("Sound Sliders")]
		[SerializeField] private Slider masterVolume;
		[SerializeField] private Slider musicVolume;

		[Header("Slider Text")]
		[SerializeField] private TextMeshProUGUI masterVolumeText;
		[SerializeField] private TextMeshProUGUI musicVolumeText;

		[Header("Mixers")]
		[SerializeField] private AudioMixer masterMixer;

		private void Start()
		{
			masterVolume.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
			masterVolumeText.text = "Master Volume: " + Mathf.Round(masterVolume.value * 100) + "%";
			musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
			musicVolumeText.text = "Music Volume: " + Mathf.Round(musicVolume.value * 100) + "%";
		}

		public void ChangeVolume(Slider slider)
		{
			if (slider.name == "MasterVolume")
			{
				masterMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume.value) * 20);
				PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
				masterVolumeText.text = "Master Volume: " + Mathf.Round(masterVolume.value * 100) + "%";
			}
			else if (slider.name == "MusicVolume")
			{
				masterMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume.value) * 20);
				PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
				musicVolumeText.text = "Music Volume: " + Mathf.Round(musicVolume.value * 100) + "%";
			}
		}
	}
}