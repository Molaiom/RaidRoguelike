using Unity.Netcode;
using UnityEngine;

namespace Characters
{
	[RequireComponent(typeof(NetworkObject))]
	public class PlayerNetworkSetup : NetworkBehaviour
	{
		[Header("Disable on non local players")]
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
}