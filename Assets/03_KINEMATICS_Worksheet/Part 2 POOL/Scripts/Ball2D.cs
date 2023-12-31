using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        float distance = Util.FindDistance(Position, new HVector2D(x,y)); //finds distance between ball position and the position of the object that it is colliding with
        return distance <= Radius; //returns whether the distance between the ball and object is more than the redius
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime); 

        /*HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = Util.FindDistance(a, b); //to test out the find distance function in util*/ 
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x * deltaTime; //physics formule for displacement
        float displacementY = Velocity.y * deltaTime;

        Position.x += displacementX; //adds the displacement to the position to make it "move" (updating the position)
        Position.y += displacementY;

        transform.position = new Vector2(Position.x, Position.y); //updates the position to the new calculated position of the ball
    }
}

