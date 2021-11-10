using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rail : MonoBehaviour
{
    #region FIELD
    // Start point is linked to the transform pivot
    public Vector3 StartPoint
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // Basic direction vector (hide?)
    public Vector3 Direction = Vector3.forward;

    // Used both - choose (compatibility issue)
    public Rail _nextRail = null;
    public Rail NextRail
    {
        get { return _nextRail; }
        set { _nextRail = value; }
    }

    // Property not needed?
    private bool _endFromRail = true;
    public bool EndFromRail
    {
        get { return _endFromRail; }
        set { _endFromRail = value; }
    }

    // End point is calculated based on direction or next rail
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
    #endregion

    #region CART

    public Cart Cart; ///  later list of carts;
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
        Gizmos.DrawLine(StartPoint, EndPoint);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(StartPoint, Cube.Vector);
        if (NextRail == null || EndPoint != NextRail.StartPoint)
            Gizmos.color = Color.red;
        Gizmos.DrawWireCube(EndPoint, Cube.Vector * 1.25f);
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
