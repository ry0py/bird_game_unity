using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    /* Todo:ゲームオーバー用のUIとスコアを表示できるようにする
            プレイ中にもスコアを表示できるようにする
            問題はスコアの保存と表示
    */
    BirdMove bird_move;
    public static int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hpText;

    [SerializeField] private Text gameOverText;
    void Start()
    {
        GameObject bird_obj = GameObject.Find("Red_A");
        bird_move = bird_obj.GetComponent<BirdMove>();
    }
    void Update()
    {
        scoreText.text = "Score: " + bird_move.GetScore.ToString();
        hpText.text = "HP: " + bird_move.GetHP.ToString();
        if(bird_move.GetHP<=0){
            score = bird_move.GetScore;
            gameOverText.text = "死";
            SceneManager.LoadScene("GameOver");
        }
        // Debug.Log(scoreText.text);//objectの中のスクリプトを読まないと変数が書き変わってくれない
    }
}
