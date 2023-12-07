using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3]; //3x3 array

    public HMatrix2D() //default constructor
    {
        Entries = new float[3, 3];
    }

    public HMatrix2D(float[,] multiArray) //2d array taken into for loop to be set to entries
    {
        for (int y = 0; y < 3; y++) // 3 columns
        {
            for (int x = 0; x < 3; x++) // 3 rows
            {
                Entries[x, y] = multiArray[x, y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right) //operator overloading for addition
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[x, y] = left.Entries[x, y] + right.Entries[x, y]; //the element from left gets added with an element from right which is in the exact same row and column
            }
        }

        return result;  
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right) //operator overloading for subtraction
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[x, y] = left.Entries[x, y] - right.Entries[x, y]; //the element from left gets subtracted with an element from right which is in the exact same row and column
            }
        }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar) //operator overloading for multiplication with scalar
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[x, y] = left.Entries[x, y] * scalar; //every element is multiplied by the same scalar
            }
        }

        return result;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right) //operator overloading for vector-matrix multiplication
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );

    }

    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right) //operator overload for matrix by matrix multiplication
    {
        return new HMatrix2D
        (

                /*00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx*/

            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],


                /*00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx*/

            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],


            /*  00 01 02    xx xx 02
                xx xx xx    xx xx 12
                xx xx xx    xx xx 22*/

            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],


            /*  xx xx xx    00 xx xx
                10 11 12    10 xx xx
                xx xx xx    20 xx xx*/

            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],


            /*  xx xx xx    xx 01 xx
                10 11 12    xx 11 xx
                xx xx xx    xx 21 xx*/

            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],


            /*  xx xx xx    xx xx 02
                10 11 12    xx xx 12
                xx xx xx    xx xx 22*/

            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],


            /*  xx xx xx    00 xx xx
                xx xx xx    10 xx xx
                20 21 22    20 xx xx*/

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],


            /*  xx xx xx    xx 01 xx
                xx xx xx    xx 11 xx
                20 21 22    xx 21 xx*/

            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],


            /*  xx xx xx    xx xx 02
                xx xx xx    xx xx 12
                20 21 22    xx xx 22*/

            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right) //operator overloading for equals to
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[x, y] != right.Entries[x, y]) //goes through every element and returns false if any one of the left/right element doesnt match the other
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right) //same as above but opposite
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[x, y] != right.Entries[x, y])
                {
                    return true;
                }
            }
        }

        return false;
    }

    /*public HMatrix2D transpose()
    {
        return // your code here
    }*/

    /*public float GetDeterminant()
    {
        return // your code here
    }*/

    public void SetIdentity() //set the matrix to an identity matrix for future transforming
    {
        /*for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == y)
                {
                    Entries[x, y] = 1;
                }
                else
                {
                    Entries[x, y] = 0;
                }
            }
        }*/

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = x == y ? 1 : 0; //ternary operator to check if the row number is equal to the column number, turning the value to 1, if not, value is 0
            }
        }
    }

    public void SetTranslationMat(float transX, float transY) //translation matrix
    {
        SetIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg) //rotation matrix
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //converts degree to radian
        Entries[0,0] = Mathf.Cos(rad); //the formula in slides
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
