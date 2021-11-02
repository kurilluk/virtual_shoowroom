using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cube
{
    private static float _size = 0.05f;
    public static float Size 
    {
        get { return _size; }
        set 
        { 
            Vector = new Vector3(value, value, value);
            _size = value;
        }
    }

    public static Vector3 Vector;
}

public class Rail : MonoBehaviour
{
    public Vector3 StartPoint
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Vector3 Direction = Vector3.forward;

    public Vector3 EndPoint
    {
        get 
        { 
            if (_endFromRail && NextRail != null)
                return NextRail.StartPoint;
            else
            return StartPoint + Direction;
        }

        set 
        { 
            Direction = value - StartPoint;
            UnityEditor.SceneView.RepaintAll();
        }
    }

    public  Rail _nextRail = null;
    public Rail NextRail
    {
        get { return _nextRail; }
        set { _nextRail = value; }
        //    {
        //    if (value != null)
        //    {
        //        // Backup previous setup of direction
        //        _endPointTemp = EndPoint;
        //        EndPoint = value.StartPoint;
        //    }
        //    //else if(_endPointTemp != null || _endPointTemp != Vector3.zero)
        //    //{   
        //    //    // Reload beckuped setup of direction
        //    //    EndPoint = _endPointTemp;
        //    //    Debug.Log("I an here");
        //    //}
        //// always set value to _nextRail
        //_nextRail = value;
        //}
    }

    private Vector3 _endPointTemp = Vector3.zero;
    private bool _endFromRail = true;
    public bool EndFromRail
    {
        get
        {
            return _endFromRail;
        }
        set
        {
            //if (NextRail != null && value)
            //{
            //    _endPointTemp = EndPoint;
            //    EndPoint = NextRail.StartPoint;
            //    Debug.Log("Temp point:" + _endPointTemp);
            //}
            //else if (!value && _endPointTemp != Vector3.zero)
            //{
            //    //EndPoint = _endPointTemp;
            //    //Debug.Log("Tempujem:" + _endPointTemp);
            //}

            _endFromRail = value;
        }
    }

    private void Clone(ref Vector3 a, Vector3 b)
    {
        a.x = b.x;
        a.y = b.y;
        a.z = b.z;
    }



    //public void ImChanged()
    //{
    //    Debug.Log("I have changed to");
    //}

    public Cart Cart; ///  later list of carts;


    //public Vector3 EndPoint;

    //[SerializeField]
    //private Vector3 _startingPoint = Vector3.zero;

    //public Vector3 StartPoint;

    //public Vector3 StartPoint
    //{
    //    get
    //    {
    //        if (NextRail == null)
    //            return _startingPoint;
    //        else
    //            return NextRail.transform.position;
    //    }
    //    set
    //    { _startingPoint = value; }
    //}

    // Start is called before the first frame update
    void Start()
    {
       //_startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Cart != null)
        {
            float distance = Distance(Cart.transform.position);
            Debug.Log("RAIL: LINE, Distance: "+ distance);
            if(distance > 0.01f)
            Cart.Move(); /// moving forward now
            else
            {
            NextRail.AddCart(Cart);
            Cart = null;  
            Debug.Log("RAIL: done - next turn.");
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(StartPoint,EndPoint);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(StartPoint, Cube.Vector);
        if(NextRail == null || EndPoint != NextRail.StartPoint)
            Gizmos.color = Color.red;
        Gizmos.DrawWireCube(EndPoint, Cube.Vector*1.25f);
    }

    public void AddCart(Cart cart)
    {
        this.Cart = cart;
        cart.currentRail = this;
    }

    public float Distance(Vector3 position)
    {
       return Vector3.Distance(position, transform.position);
    }
}
