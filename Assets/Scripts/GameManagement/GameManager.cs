using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int score;
    [SerializeField]
    private int scoreMultiplier = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Animator scoreAnim;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (PowerupManager.instance.hasMultiplier)
        {
            scoreMultiplier = 2;
        }
        else
        {
            scoreMultiplier = 1;
        }
    }


    public void UpdateScore(int newScore)
    {
        score += newScore * scoreMultiplier;
        scoreText.text = score.ToString();
        scoreAnim.SetTrigger("scoreUp");
    }

}
