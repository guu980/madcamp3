using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFriction : MonoBehaviour
{
    public float Friction = 0.4f;

    private HingeJoint _hinge;
    private Rigidbody _thisBody;
    private Rigidbody _connectedBody;
    private Vector3 _axis;  //local space

    // Start is called before the first frame update
    void Start()
    {
        _hinge = GetComponent<HingeJoint>();
        _connectedBody = _hinge.connectedBody;
        _axis = _hinge.axis;

        _thisBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var angularV = _hinge.velocity;
        //Debug.Log("angularV " + angularV);
        var worldAxis = transform.TransformVector(_axis);
        var worldTorque = Friction * angularV * worldAxis;

        _thisBody.AddTorque(-worldTorque);
        _connectedBody.AddTorque(worldTorque);
    }
}
