//// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); //object initisl podition

        Translate(1,1); //testing translation
        Rotate(45); //testing rotation
    }


    void Translate(float x, float y)
    {
        transformMatrix.SetIdentity(); //set to identity matrix to transform
        transformMatrix.SetTranslationMat(x, y);
        Transform();

        pos = transformMatrix * pos; //update the position
    }

    void Rotate(float angle)
    {
        transformMatrix.SetIdentity(); 

        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y); //matrix concatenation in slides - translates point to origin
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y); //translates point back from origin

        rotateMatrix.SetRotationMat(angle); //rotate with angle of rotation

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; //matrix multiplication of the transformation

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert; ;//apllies transformation to the vertices
            vertices[i].x = vert.x; //update vertices
            vertices[i].y = vert.y;
        }

        meshManager.clonedMesh.vertices = vertices; //updat ethe cloned mesh's vertices to the new calculated vertices
    }
}
