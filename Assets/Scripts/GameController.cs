using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameController : MonoBehaviourPunCallbacks
{
    public BallMovement ballMovement { get; set; }
    int _playerScore;
    int _computerScore;
    [SerializeField]
    TextMeshProUGUI playerScore;
    [SerializeField]
    TextMeshProUGUI computerScore;
    PhotonView pv;
    public static GameController Instance
    {
        get { return gameController; }
    }
    static GameController gameController;
    void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        ScoringZone.OnCollisionWithWall += BallTouched;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BallTouched(string name)
    {
        if (pv.IsMine)
        {
            Hashtable ht = new Hashtable();
            // print("namw "+name);
            if (name == "LeftWall")
            {
                Player1Scored();
                ht.Add("Player1Scored", _playerScore);
            }
            else if (name == "RightWall")
            {
                Player2Scored();
                ht.Add("Player2Scored", _computerScore);
            }
            PhotonNetwork.LocalPlayer.SetCustomProperties(ht);
            ballMovement.ResetPosition();
            ballMovement.StartingForce();
        }
    }

    void Player1Scored()
    {
        _playerScore++;
        // print("_playerScore "+_playerScore);
        playerScore.text = _playerScore.ToString();

        // ballMovement.ResetPosition();
        // ballMovement.StartingForce();
    }

    void Player2Scored()
    {
        _computerScore++;
        computerScore.text = _computerScore.ToString();
        // ballMovement.ResetPosition();
        // ballMovement.StartingForce();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        ballMovement.ResetPosition();
        ballMovement.StartingForce();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (!pv.IsMine)
        {
            if (changedProps["Player1Scored"] != null && (int)changedProps["Player1Scored"] != _playerScore)
            {
                Player1Scored();
            }
            else if (changedProps["Player2Scored"] != null && (int)changedProps["Player2Scored"] != _computerScore)
            {
                Player2Scored();
            }
        }
    }

}
