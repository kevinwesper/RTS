using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatsSettings : ScriptableObject {

	public float maxHp;
	public float currentHP;
	public bool charAttacking;
	public float hpRegen;
	public float maxStamina;
	public float currentStamina;
	public float dodgeStaminaCost;
	public float sprintingStaminaCost;
	public float staminaRechargeRate;
	public float woodSpiritHP;
	public float woodSpiritCurHP;
	public float woodSpiritDMG;
	public float lucyHP;
	public float lucyCurHP;
	public float lucyDMG;
	public float wolfHP;
	public float snailHP;
	public float lightAttackDMG;
	public float lightAttackCost;
	public float heavyAttackDMG;
	public float heavyAttackCost;
	public float debufDMG;

	[HideInInspector]
	public bool enemyAttacking=false;
	public bool enemyHitFromLeft=false;
	public bool enemyHitFromRight=false;
}
