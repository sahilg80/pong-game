using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField]
    BallMovement ballMovement;
    int _playerScore;
    int _computerScore;
    [SerializeField]
    TextMeshProUGUI playerScore;
    [SerializeField]
    TextMeshProUGUI computerScore; 
    // Start is called before the first frame update
    void Start()
    {
        ScoringZone.OnCollisionWithWall += BallTouched;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BallTouched(string name){
        // print("namw "+name);
        if (name == "LeftWall")
        {
            PlayerScored();
        }
        else if(name == "RightWall"){
            ComputerScored();
        }
    }

    void PlayerScored(){
        _playerScore++;
        // print("_playerScore "+_playerScore);
        playerScore.text = _playerScore.ToString();
        
        ballMovement.ResetPosition();
        ballMovement.StartingForce();
    }

    void ComputerScored(){
        _computerScore++;
        computerScore.text = _computerScore.ToString();
        ballMovement.ResetPosition();
        ballMovement.StartingForce();
    }
}
