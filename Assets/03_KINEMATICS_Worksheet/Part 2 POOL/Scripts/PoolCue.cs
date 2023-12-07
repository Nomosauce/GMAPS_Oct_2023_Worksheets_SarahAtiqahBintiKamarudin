using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //check if left mouse button is pressed
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing //mouse position gets turned into the start position/point
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y)) //checke if ball exist and if mouse point is colliding with the ball
            {
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 2, Color.red); //creates the line from mouse point to ball's point
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null) //checks if left mouse button is released
        {
            drawnLine.EnableDrawing(false); //no more line drawing

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);
            ball.Velocity = v; //sets the velocity of the ball to go to the opposite direction of thr mouse point

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive(); //list of active lines

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false); //disables each of the active lines that were in the list
        }
    }
}
