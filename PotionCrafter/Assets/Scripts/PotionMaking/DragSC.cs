using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Dragable : MonoBehaviour
{
    public float damping;
    public float frequency;
    public LayerMask draglayer;
    private TargetJoint2D joint;

    private void Update()
    {
        var worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            var draggingobjectcollider = Physics2D.OverlapPoint(worldpos, draglayer);
            if (!draggingobjectcollider)
            {
                return;
            }
            var dragginobjectbody = draggingobjectcollider.attachedRigidbody;
            if (!dragginobjectbody)
            {
                return;
            }
            joint = dragginobjectbody.gameObject.AddComponent<TargetJoint2D>();
            joint.dampingRatio = damping;
            joint.frequency = frequency;
            joint.anchor = joint.transform.InverseTransformPoint(worldpos);
            
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(joint);
            joint = null;
        }


        if (joint)
        {
            joint.target = worldpos;

            Vector3 euler = joint.connectedBody.transform.eulerAngles;
            if (euler.z > 180)
            {
                euler.z = euler.z - 360;
            }
            euler.z = Mathf.Clamp(euler.z, -25, 25);
            joint.connectedBody.transform.eulerAngles = euler;
        }
    }
}
