using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayersPhoton : MonoBehaviour
{
    [SerializeField]
    GameObject _playerPaddle;
    // [SerializeField]
    // GameObject _spawnLocator;
    // Start is called before the first frame update
    void OnEnable()
    {
        // InputController.OnJoinRoomDone += SpawnPlayerOne;
        // InputController.OnCreateRoomDone += SpawnPlayerTwo;
    }

    void OnDisable()
    {
        // InputController.OnJoinRoomDone -= SpawnPlayerOne;
        // InputController.OnCreateRoomDone -= SpawnPlayerTwo;
    }
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            PhotonNetwork.Instantiate(_playerPaddle.name, transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(_playerPaddle.name, new Vector3(-transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnPlayerOne()
    {
       // PhotonNetwork.Instantiate(_playerPaddle.name, transform.position, Quaternion.identity);
    }

    void SpawnPlayerTwo()
    {
//PhotonNetwork.Instantiate(_playerPaddle.name, new Vector3(-transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

}
