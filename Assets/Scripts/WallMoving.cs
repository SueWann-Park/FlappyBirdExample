using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
    private readonly float moveCoff = 0.2f;
    private List<Transform> walls;
    private readonly float wallInterval = 12f;

    void Start()
    {
        walls = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++)
        {
            walls.Add(transform.GetChild(i));
            SetPosAndColor(walls[i]);
        }
    }

    // invariant: wall has two child, which have SpriteRenderer component.
    private void SetPosAndColor(Transform wall)
    {
        wall.localPosition = new Vector3(walls[walls.Count - 1].localPosition.x + wallInterval, GetNewY(), 0);
        
        Color c = GetRandomColor();
        wall.GetChild(0).GetComponent<SpriteRenderer>().color = c;
        wall.GetChild(1).GetComponent<SpriteRenderer>().color = c;
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    private float GetNewY()
    {
        return Random.Range(-9f, 9f);
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < walls.Count; i++)
        {
            walls[i].position += Vector3.left * moveCoff;
        }

        if (walls[0].localPosition.x < -40.0f)
        {
            SetPosAndColor(walls[0]);
            walls.Add(walls[0]);
            walls.RemoveAt(0);
        }
    }
}
