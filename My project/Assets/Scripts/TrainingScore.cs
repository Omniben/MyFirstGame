using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainingScore : MonoBehaviour
{
    public GameObject target;

    public int Score = 0;

    [SerializeField] private TextMeshPro currentScoreText;


    void Start()
    {

       
    }



    void Update()
    {

        if(target != null)
        {

            Target enemy = target.GetComponent<Target>();

            if (enemy != null)
            {

                if (enemy.isDead)
                {
                    addScore();
                    UpdateScore(Score);
                    Destroy(target);
                }
            }
        }
        

        

    }

    public void UpdateScore(int currentScore)
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void addScore()
    {
         Score ++;
    }

    public void resetScore()
    {
        Score = 0;
    }
}
