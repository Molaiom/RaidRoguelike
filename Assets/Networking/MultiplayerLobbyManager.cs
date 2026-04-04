using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class MultiplayerLobbyManager : MonoBehaviour
{
	[SerializeField] private NetworkManager networkManager;
	[SerializeField] private GameObject canvas;

	public void HostGame()
	{
		StartCoroutine(HostGameRoutine());
		IEnumerator HostGameRoutine()
		{
			yield return networkManager.StartHost();
			canvas.SetActive(false);
		}
	}

	public void JoinGame()
	{
		StartCoroutine(JoinGameRoutine());
		IEnumerator JoinGameRoutine()
		{
			yield return networkManager.StartClient();
			canvas.SetActive(false);
		}
	}
}
