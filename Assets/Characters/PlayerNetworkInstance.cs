using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkObject))]
public class PlayerNetworkInstance : NetworkBehaviour
{
	[SerializeField] private GameObject cinemachineCamera;
	[SerializeField] private Camera playerCamera;
	[SerializeField] private AudioListener playerAudioListener;
	[SerializeField] private PlayerController playerControllerScript;
	private NetworkObject networkObject;

	private void Awake()
	{
		networkObject = GetComponent<NetworkObject>();
	}

	public override void OnNetworkSpawn()
	{
		base.OnNetworkSpawn();
		if (!IsOwner)
		{
			cinemachineCamera.SetActive(false);
			playerCamera.enabled = false;
			playerAudioListener.enabled = false;
			playerControllerScript.enabled = false;
		}
	}
}
