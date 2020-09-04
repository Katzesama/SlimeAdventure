using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private Text text;
    private int points;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points = GameObject.FindObjectOfType<SlimeController>().pointsTotal;
        text.text = "Score: " + points;
    }
}
