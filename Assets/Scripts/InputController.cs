using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using System;

public class InputController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_InputField _createRoomInput;
    [SerializeField]
    TMP_InputField _joinRoomInput;
    // public static event Action OnJoinRoomDone;
    // public static event Action OnCreateRoomDone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateRoom(){
        PhotonNetwork.CreateRoom(_createRoomInput.text);
    }

    public override void OnCreatedRoom()
    {
        //base.OnCreatedRoom();
        //OnCreateRoomDone();
    }

    public void JoinRoom(){
        print("joining");
        PhotonNetwork.JoinRoom(_joinRoomInput.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("messagew "+message);
        //base.OnJoinRoomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        //print(PhotonNetwork.LocalPlayer.ActorNumber);
        //base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("MultiplayerScene");
        //OnJoinRoomDone();
    }
}
