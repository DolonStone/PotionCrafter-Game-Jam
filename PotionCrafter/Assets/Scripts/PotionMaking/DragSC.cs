using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Dragable : MonoBehaviour
{
    public float damping;
    public float frequency;
    public LayerMask draglayer;
    public Transform target;
    private TargetJoint2D joint;
    public GameObject currentobject;
    public Vector3 mouseFrameMovement = Vector3.zero;
    private Vector3 lastMousePos = Vector3.zero;
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
            currentobject = draggingobjectcollider.gameObject;
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
            if (currentobject.CompareTag("Pestle"))
            {
                currentobject.transform.right = (target.position - new Vector3(0, 6, 0)) - currentobject.transform.position;
            }
            joint.target = worldpos;
            

            
        }
    }
  
   

  
}
