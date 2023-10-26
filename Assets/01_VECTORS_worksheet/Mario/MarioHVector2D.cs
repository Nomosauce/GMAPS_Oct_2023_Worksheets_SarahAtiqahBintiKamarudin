using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir.Normalize(); //normalise the move direction before flipping pos/neg values
        moveDir = moveDir * -1;

        rb.AddForce(moveDir.ToUnityVector2() * force); //and convert to unitys vector 2d

        gravityNorm = gravityDir;
        gravityNorm.Normalize(); //normalised gravity direction to set gravity strength
        rb.AddForce(gravityNorm.ToUnityVector2() * gravityStrength);

        float angle = Vector3.SignedAngle(Vector3.right, moveDir.ToUnityVector3(), Vector3.forward); //calculate angle and convert to unitys vector 3d
        rb.MoveRotation(Quaternion.Euler(0, 0, angle)); //rotates astronauts rb component

        DebugExtension.DebugArrow(transform.position, gravityNorm.ToUnityVector3() * gravityStrength); //drawing the arrows
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3());
    }
}
