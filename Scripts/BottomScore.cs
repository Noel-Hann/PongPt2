using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomScore : MonoBehaviour
{

    public static int bottomScore;

    public static int topScore;

    public GameObject textReadout;

    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;
    public GameObject powerUp4;

    public GameObject leftPaddle;
    public GameObject rightPaddle;

    public AudioClip rightWin;
    public AudioClip leftWin;
    
    // Start is called before the first frame update
    void Start()
    {
        bottomScore = 0;
        topScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (this.name == "Bottom Trigger")
        {
            topScore++;
            textReadout.GetComponent<textScript>().rightScore++;//adding one to the right score in the textMesh
            Debug.Log($"Top team scored.");
        }
        else if (this.name == "Top Trigger")
        {
            bottomScore++;
            textReadout.GetComponent<textScript>().leftScore++;//adding one to the left score in the textMesh
            Debug.Log($"Bottom team scored.");
        }

        Debug.Log($"The new score is Top Team: { topScore}, Bottom Team: { bottomScore}");

        if (topScore == 11)
        {
            Debug.Log("Game Over, Top Team wins!");
            topScore = 0;
            bottomScore = 0;
            resetUiScores();
            GetComponent<AudioSource>().PlayOneShot(rightWin);
        }
        if (bottomScore == 11)
        {
            Debug.Log("Game Over, Bottom Team wins!");
            topScore = 0;
            bottomScore = 0;
            resetUiScores();
            GetComponent<AudioSource>().PlayOneShot(leftWin);
        }

        resetField();

    }

    private void resetUiScores()
    {
        textReadout.GetComponent<textScript>().leftScore = 0;
        textReadout.GetComponent<textScript>().rightScore = 0;
    }

    private void resetField()
    {
        powerUp1.gameObject.SetActive(true);
        powerUp2.gameObject.SetActive(true);
        powerUp3.SetActive(true);
        powerUp4.SetActive(true);
        
        leftPaddle.GetComponent<PaddleControl>().resetBounceForce();
        //rightPaddle.GetComponent<PaddleControl>().resetBounceForce();
    }
}
