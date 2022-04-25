using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster script;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(script == null)
        {
            script = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scoreText = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
        scoreText.text = "0";
    }

    public void SetScore(int score = -1)
    {
        if (score == -1)
        {
            int.TryParse(scoreText.text, out int oldScore);
            scoreText.text = (oldScore + 1).ToString();
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && Input.anyKeyDown == true)
        {
            SceneManager.LoadScene(gameObject.scene.name);
            Time.timeScale = 1;
            return;
        }
    }
}
