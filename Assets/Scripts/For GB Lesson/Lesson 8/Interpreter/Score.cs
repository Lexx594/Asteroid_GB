using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [Range(0f, 5000000f)]
    public float score;
    [SerializeField] private TextMeshProUGUI _text;

    void Start()
    {
        
    }



    void Update()
    {
        if (score >= 1000f && score < 1000000f)
        {
            int Score = (int)score / 1000;
            _text.text = $"Очки: {Score}K";
        }
        else if (score >= 1000000f)
        {
            int Score = (int)score / 1000000;
            _text.text = $"Очки: {Score}M";
        }
        else
        {
            score = Mathf.Round(score);
            _text.text = $"Очки: {score}";
        }
        

    }
}
