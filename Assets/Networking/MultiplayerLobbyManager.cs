using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class MultiplayerLobbyManager : NetworkBehaviour
{
	[SerializeField] private NetworkManager networkManager;
	[SerializeField] private GameObject canvas;

	public void HostGame()
	{
		networkManager.StartHost();
		LoadGameScene();
	}

	public void JoinGame()
	{
		networkManager.StartClient();
		LoadGameScene();
	}

	private void LoadGameScene()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
		canvas.SetActive(false);
	}
}
