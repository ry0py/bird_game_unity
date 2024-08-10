using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// [RequireComponent(typeof(Button))]
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject restart;
    [SerializeField] GameObject exit;
    [SerializeField] Text scoreText;
    Button button_restart;
    Button button_exit;

    UIControl ui_control;
    void Start()
    {
        button_restart = restart.GetComponent<Button>();
        button_exit = exit.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Scoreは" + UIControl.score.ToString()+"です";
        button_restart.onClick.AddListener(()=>SceneManager.LoadScene("TitleScene"));
        button_exit.onClick.AddListener(()=>Application.Quit());
    
    }
}
