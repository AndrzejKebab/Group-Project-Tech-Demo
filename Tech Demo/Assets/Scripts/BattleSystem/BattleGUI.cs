using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PatataStudio.Battle
{
	public class BattleGUI : MonoBehaviour
	{
		public TextMeshProUGUI nameText;
		public TextMeshProUGUI levelText;
		public Slider healthSlider;
		private Unit unit;

		public void Awake()
		{
			unit = GetComponent<Unit>();
		}
		
		private void Start()
		{
			SetGUI(unit);
		}

		private void Update()
		{
			healthSlider.value = unit.currentHeath;
		}

		public void SetGUI(Unit unit)
		{
			nameText.text = unit.unitName;
			levelText.text = "Level: " + unit.unitLevel;
			healthSlider.maxValue = unit.maxHealth;
			healthSlider.value = unit.currentHeath;

		}

		public void SetHealth(int health)
		{
			healthSlider.value = health;
			Debug.Log("set health " + healthSlider.value);
		}
	}
}
