using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    // Start is called before the first frame update
    void Start()
    {
        mat.SetIdentity();
        mat.Print(); //print out the identity matrix to test

        Question2();
    }

    public void Question2()
    {
        //testing to see if the mulitplication for matrix by matrix works
        HMatrix2D mat1 = new HMatrix2D(
        1.0f, 2.0f, 3.0f,
        4.0f, 5.0f, 6.0f,
        7.0f, 8.0f, 9.0f
        );
        HMatrix2D mat2 = new HMatrix2D(
        2.0f, 4.0f, 6.0f,
        8.0f, 10.0f, 12.0f,
        14.0f, 16.0f, 18.0f
        );
        HVector2D vec1 = new HVector2D(2.0f, 3.0f);

        HMatrix2D resultMat;

        resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
