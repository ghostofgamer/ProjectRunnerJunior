using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    private float _distanceToCheck = 0.6f;
    public bool _isGrounded;
    public Vector3 SnapPoint { get; private set; }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red, _distanceToCheck);
        Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _distanceToCheck, _groundMask);

        if (hit.collider!=null)
        {
            _isGrounded = true;
            SnapPoint = hit.collider.ClosestPoint(transform.position);
        }
        else
        {
            _isGrounded = false;
        }
    }
}
