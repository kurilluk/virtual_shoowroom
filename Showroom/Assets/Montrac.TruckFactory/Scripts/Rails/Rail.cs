using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rail : MonoBehaviour
{
    #region FIELD
    // Start point is linked to the transform pivot
    protected Vector3 _startPoint;
    public Vector3 StartPoint
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // End point is calculated based on direction or next rail
    protected Vector3 _endPoint;
    public Vector3 EndPoint
    {
        get
        {
            if (nextRail != null && endFromRail)
                return nextRail.StartPoint;
            else
                return _endPoint;
        }

        set { _endPoint = value; UnityEditor.SceneView.RepaintAll(); } //UnityEditor.SceneView.RepaintAll();}
    }

    // Next Rail for topology connection and end point definition
    [SerializeField]
    public Rail nextRail;

    // Property not needed?
    public  bool endFromRail ;

    //public Rail NextRail
    //{
    //    get { return _nextRail; }
    //    set { _nextRail = value; }
    //}

    // Basic direction vector (hide?)
    //public Vector3 Direction = Vector3.forward;

    //public bool EndFromRail
    //{
    //    get { return _endFromRail; }
    //    set { _endFromRail = value; }
    //}
    #endregion


    private void Awake()
    {
        _startPoint = transform.position;
        _endPoint = transform.position;
        nextRail = null;
        endFromRail = false;
    }

    #region CART

    protected Cart Cart; ///  later list of carts;
    public void AddCart(Cart cart)
    {
        this.Cart = cart;
        cart.currentRail = this;
    }

    private int _possible_movement = Animator.StringToHash("Move_110");

    public int Movement
    {
        get { return _possible_movement; }
        private set { _possible_movement = value; }
    }
    #endregion


    #region GIZMOS

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(StartPoint, EndPoint);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(StartPoint, Vector3.one * 0.05f);
        if (nextRail == null || EndPoint != nextRail.StartPoint)
            Gizmos.color = Color.red;
        Gizmos.DrawWireCube(EndPoint, Vector3.one * 0.075f);
    }

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

    #endregion

    #region TRASH
    //private Vector3 _endPointTemp = Vector3.zero;

    //private void Clone(ref Vector3 a, Vector3 b)
    //{
    //    a.x = b.x;
    //    a.y = b.y;
    //    a.z = b.z;
    //}
    //public float Distance(Vector3 position)
    //{
    //    return Vector3.Distance(position, transform.position);
    //}
    #endregion
}
