using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float RotationSpeed;
    public float ForwardSpeed;
    public float SideWaysSpeed;
    public GameObject MainCamera;
    private bool _isMoving;
    public bool IsMoving => _isMoving;


    [SerializeField]
    private Animator _anim; 

    [Range(1,5)]
    public float RunningSpeedScaler;

    [SerializeField]
    private Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private float _horizontal, _vertical;

    void Update()
    {
        var rotation = Mathf.Lerp(transform.rotation.y, MainCamera.transform.rotation.y,RotationSpeed);
        transform.rotation = new Quaternion(transform.rotation.x,MainCamera.transform.rotation.y, transform.rotation.z,transform.rotation.w);

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 velocity = transform.forward*ForwardSpeed*_vertical + transform.right*SideWaysSpeed*_horizontal; 
        _rb.velocity = velocity*Time.fixedDeltaTime;
        if(velocity!= Vector3.zero)
        {
            _anim.SetInteger("transition", 1);
            _isMoving = true;
        }
        else
        {
            _anim.SetInteger("transition", 0);
            _isMoving = false;
        }
    }
}
       

