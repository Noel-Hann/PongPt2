using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class textScript : MonoBehaviour
{

    public int leftScore;
    public int rightScore;
    public GameObject scores;
    
    public string text;
    private TextMeshProUGUI _textMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;

        _textMesh = GetComponent<TextMeshProUGUI>();
        
        Text myText = GetComponent<Text>();
        //myText.text = "Left: " + leftScore + "Right: " + rightScore;
    }

    // Update is called once per frame
    void Update()
    {
        //leftScore = scores.GetComponent<BottomScore>().bottomScore;
       //rightScore = scores.topScore;
        _textMesh.text = "Left: " + leftScore + "Right: " + rightScore;

        if (leftScore > 8 || rightScore > 8)
        {
            _textMesh.color = new Color(255, 59, 0, 255);
        }
        else if (leftScore == 0 && rightScore == 0)
        {
            _textMesh.color = new Color(255, 0, 255, 255);
        }
    }
}
