using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMain : MonoBehaviour
{
    private readonly float moveCoff = 0.25f;
    private bool isSpacePushed;
    
    void Start()
    {
        isSpacePushed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != Layer.Wall)
            return;

        Time.timeScale = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != Layer.Scorer)
            return;

        GameMaster.script.SetScore();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            isSpacePushed = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) == true)
        {
            isSpacePushed = false;
        }
    }

    private void FixedUpdate()
    {
        float newY = transform.position.y + (isSpacePushed == true ? moveCoff : -moveCoff);
        newY = Mathf.Clamp(newY, -9.5f, 9.5f);

        transform.position = new Vector3(transform.position.x, newY, 0);
    }
}
