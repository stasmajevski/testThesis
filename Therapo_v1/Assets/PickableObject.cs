using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform TransformCamera;
    public LayerMask Raymask;
    private RaycastHit hit;
    private Transform currentTransform;
    private float length;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(TransformCamera.position, TransformCamera.forward
                , out hit, 3f, Raymask))
            {
                if (hit.transform.tag == "PickableObject")
                {
                    SetNewTransform(hit.transform);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RemoveTransform();
        }

        if(currentTransform)
        {
            MoveTransformAround();
        }
    }

    public void SetNewTransform(Transform newTransform)
    {
        if (currentTransform)
        {
            return;
        }
        currentTransform = newTransform;
        length = Vector3.Distance(TransformCamera.position, newTransform.position);

        currentTransform.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void MoveTransformAround()
    {
        currentTransform.position = TransformCamera.position + TransformCamera.forward * length;
    }

    public void RemoveTransform()
    {
        if(!currentTransform)
        {
            return;
        }

        currentTransform.GetComponent<Rigidbody>().isKinematic = false;
        currentTransform = null;
    }

}
