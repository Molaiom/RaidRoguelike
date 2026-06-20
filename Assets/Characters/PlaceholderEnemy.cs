using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class PlaceholderEnemy : NetworkBehaviour
{
	[SerializeField] private Image healthBarImg;
	[SerializeField] private int maxHealth;
	NetworkVariable<int> currentHealth = new NetworkVariable<int>();

	private void Awake()
	{
		if (!IsClient)
		{
			currentHealth.OnValueChanged += UpdateHealthBar;
			currentHealth.Value = maxHealth;
		}
	}

	public override void OnDestroy()
	{
		currentHealth.OnValueChanged = null;
	}

	public void ModifyHealth(int amount)
	{
		if (currentHealth.Value + amount <= 0)
		{
			currentHealth.Value = 0;
			Destroy(gameObject);
		}
		else
			currentHealth.Value += amount;
	}

	private void UpdateHealthBar(int previousValue, int newValue)
	{
		healthBarImg.fillAmount = (float)(newValue / maxHealth);
		Debug.Log($"Health changed! from: {previousValue} to {newValue}!");

	}
}
