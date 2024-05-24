using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Starter starter;

    private bool started= false;//false

    private int scoreLeft= 0;
    private int scoreRight= 0;

    private BallController ballController;
    
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.ballController= this.ball.GetComponent<BallController>();
        this.startingPosition= this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.started)
            return;
        
        if(Input.GetKey(KeyCode.Space)){
            this.started=true;
            this.starter.StartCountdown();
        }
    }
//     void Update()
// {
//     if (Input.GetKeyDown(KeyCode.Space)) {
//         //this.started = !
//         this.started;  // Toggle the started state
//         if (this.started) {
//             this.ballController.Go();
//         } else {
//             this.ballController.Stop();
//         }
//     }
// }


    public void ScoreGoalRight(){
        Debug.Log("Goooooooooooooooooooooooolllllllllllllllllll by LLLLLLEEEEFFFFTTTT");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }
    public void ScoreGoalLeft(){
        Debug.Log("Goooooooooooooooooooooooolllllllllllllllllll by RRRRRRRIIIIGGGGHHHTTT ");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }
    private void UpdateUI(){
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
    private void ResetBall(){
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }
    public void StartGame(){
        this.ballController.Go();
    }
}
