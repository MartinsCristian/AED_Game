using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
	public Image HealthBar;
	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		HealthBar.fillAmount = unit.maxHP;
		//hpSlider.maxValue = unit.maxHP;
		//hpSlider.value = unit.currentHP;
	}

	public void SetHP(Unit unit)
	{
		HealthBar.fillAmount = unit.currentHP / unit.maxHP;
	}
}
