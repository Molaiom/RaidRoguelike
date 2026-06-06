using UnityEngine;
using Unity.Netcode;
using System.Collections;
using Unity.Netcode.Transports.UTP;
using TMPro;

public class MultiplayerLobbyManager : MonoBehaviour
{
	[SerializeField] private NetworkManager networkManager;
	[SerializeField] private UnityTransport unityTransport;
	[SerializeField] private GameObject canvas;
	[SerializeField] private TMP_InputField ipInputField;
	[SerializeField] private TMP_InputField portInputField;

	public void HostGame()
	{
		StartCoroutine(HostGameRoutine());
		IEnumerator HostGameRoutine()
		{
			unityTransport.ConnectionData.Address = ipInputField.text;
			unityTransport.ConnectionData.Port = ushort.Parse(portInputField.text);
			yield return networkManager.StartHost();
			canvas.SetActive(false);
		}
	}

	public void JoinGame()
	{
		StartCoroutine(JoinGameRoutine());
		IEnumerator JoinGameRoutine()
		{
			unityTransport.ConnectionData.Address = ipInputField.text;
			unityTransport.ConnectionData.Port = ushort.Parse(portInputField.text);
			yield return networkManager.StartClient();
			canvas.SetActive(false);
		}
	}
}
