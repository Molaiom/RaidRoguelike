using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkObject))]
public class PlayerNetworkInstance : NetworkBehaviour
{
	[SerializeField] private GameObject cinemachineCamera;
	[SerializeField] private Camera playerCamera;
	[SerializeField] private AudioListener playerAudioListener;
	private NetworkObject networkObject;

	private void Awake()
	{
		networkObject = GetComponent<NetworkObject>();
	}

	public override void OnNetworkSpawn()
	{
		base.OnNetworkSpawn();
		if (!networkObject.IsLocalPlayer)
		{
			cinemachineCamera.SetActive(false);
			playerCamera.enabled = false;
			playerAudioListener.enabled = false;
		}
	}
}
