using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayersPhoton : MonoBehaviour
{
    [SerializeField]
    GameObject _playerPaddle;
    [SerializeField]
    GameObject _ball;
    [SerializeField]
    Transform spawnLoc1;
    [SerializeField]
    Transform spawnLoc2;
    [SerializeField]
    Transform ballSpawnLoc;
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
            GameObject spawned = PhotonNetwork.Instantiate(_playerPaddle.name, spawnLoc1.position, Quaternion.identity);
            //spawned.transform.SetParent(transform);
        }
        else
        {
            GameObject spawned = PhotonNetwork.Instantiate(_playerPaddle.name, spawnLoc2.position, Quaternion.identity);
            //spawned.transform.SetParent(transform);        
        }
        // if (PhotonNetwork.IsMasterClient)
        // {
        //     GameObject spawnedBall = PhotonNetwork.InstantiateRoomObject(_ball.name, ballSpawnLoc.position, Quaternion.identity);
        //     // GameController.Instance.ballMovement = spawnedBall.GetComponent<BallMovement>();
        // }
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
