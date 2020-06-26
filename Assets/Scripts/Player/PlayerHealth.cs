using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public event Action playerDie;
	public int maxHealth;
	public int currentHealth;

	public HealthBar healthBar;


	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);


		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
		Destroy(healthBar);
		playerDie();
	}
}