using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

public class PlaceholderEnemy : NetworkBehaviour
{
	[SerializeField] private Image healthBarImg;
	//[SerializeField] private int maxHealth;
	private const int maxHealth = 15;
	NetworkVariable<int> currentHealth = new NetworkVariable<int>(maxHealth);

	public override void OnNetworkSpawn()
	{
		if (IsServer)
		{
			currentHealth.Value = maxHealth;
			NetworkManager.OnClientConnectedCallback += OnClientConnectedCallback;
		}
		else
		{
			Debug.Log($"Enemy Health is {currentHealth.Value} when spawned.");
		}
		currentHealth.OnValueChanged += UpdateHealthBar;
	}

	public override void OnNetworkDespawn()
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

	private void OnClientConnectedCallback(ulong obj)
	{
		UpdateHealthBar(maxHealth, currentHealth.Value);
		NetworkManager.OnClientConnectedCallback -= OnClientConnectedCallback;
	}

	private void UpdateHealthBar(int previousValue, int newValue)
	{
		healthBarImg.fillAmount = (float)newValue / maxHealth;
		Debug.Log($"Health changed! from: {previousValue} to {newValue}!");
	}
}
