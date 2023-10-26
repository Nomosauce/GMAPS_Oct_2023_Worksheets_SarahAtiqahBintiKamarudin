using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = planet.position - transform.position; //vector from player to planet
        moveDir = new Vector3(gravityDir.y,-gravityDir.x,0f); //flipped the xy axis to make perpendicular
        moveDir = moveDir.normalized * -1f; //normalise to flip pos/neg signs

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength); //normalised gravity direction to set gravity strength

        float angle = Vector3.SignedAngle(Vector3.right, moveDir, Vector3.forward); //calculate angle (to rotate sprite?)

        rb.MoveRotation(Quaternion.Euler(0, 0, angle)); //rotates astronauts rb component

        DebugExtension.DebugArrow(transform.position, gravityNorm * gravityStrength); //drawing the arrows
        DebugExtension.DebugArrow(transform.position, moveDir);
    }
}


