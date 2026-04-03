using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System.Collections;

public class MultiplayerLobbyManager : NetworkBehaviour
{
	[SerializeField] private NetworkManager networkManager;
	[SerializeField] private GameObject canvas;

	public void HostGame()
	{
		StartCoroutine(HostGameRoutine());
		IEnumerator HostGameRoutine()
		{
			yield return networkManager.StartHost();
			LoadGameScene();
		}
	}

	public void JoinGame()
	{
		StartCoroutine(JoinGameRoutine());
		IEnumerator JoinGameRoutine()
		{
			yield return networkManager.StartClient();
			LoadGameScene();
		}
	}

	private void LoadGameScene()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		canvas.SetActive(false);
	}
}
