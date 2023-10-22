using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(3, -2); // set starting point of the vector to be 0x 0y, and vector2 is used as its 2D
        endPt = new Vector2(-2, 3); // set end point of the vector to br 2x 3y, so the line goes from 0,0 to 2,3

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black); //uses the data that references that start, end, width and colour to initialise the line
        drawnLine.EnableDrawing(true); //activates the line

        Vector2 vec2 = endPt - startPt; //magnitude or the length of line
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++) //iterates this code n amount of times based on how many lines are needed
        {
            startPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)); 

            endPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0), //start position
            new Vector3(5, 5, 0), //direction or end position of vector
            Color.red, 
            60f); //seconds appearing for
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY));

            endPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY));

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minY,maxY)),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a-b; //a+b = (3+ -4, 5 +2)

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + Vector3.Magnitude(a.ToUnityVector3()).ToString("F2"));
        Debug.Log("Magnitude of b = " + Vector3.Magnitude(b.ToUnityVector3()).ToString("F2"));
        Debug.Log("Magnitude of c = " + Vector3.Magnitude(c.ToUnityVector3()).ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(
            new Vector3(1,0,0), 
            b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);


    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
