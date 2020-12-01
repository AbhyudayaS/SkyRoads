using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public GameObject Ship;

    [Tooltip("In ms^-1")] [SerializeField] float horizontalSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float forwardSpeed = 20f;

    //[SerializeField] float positionPitchFactor = -5f;
    //[SerializeField] float controlPitchFactor = -20f;
    //[SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    public float _jumpmultiplier = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    private Rigidbody _rigidbody;
    private PlayerCollision playerCollision;

    private bool _jump = false;  
    private bool _isGrounded;
    private Vector3 initLocation;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        initLocation = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        playerCollision = GetComponent<PlayerCollision>();
        GameManager.onGameStart += Reset;
    }

    private void Reset()
    {
        gameObject.SetActive(true);        
        transform.position = initLocation;
    }

    private void Update()
    {
        ReadInput();        
        _isGrounded = playerCollision.isGrounded;

        //Fall multiplier for jump
        ApplyFallMutltiplier();

    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jump = true;
        }

        xThrow = Input.GetAxis("Horizontal");     
    }

    private void ProcessTranslation()
    {
        float xOffset = xThrow * horizontalSpeed * Time.deltaTime;       
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y;       

        transform.localPosition = new Vector3(rawXPos, rawYPos, transform.localPosition.z);
    }

    private void ApplyFallMutltiplier()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {        
        Jump();
        //MoveForward();
        ProcessRotation();
        ProcessTranslation();
    }

    private void ProcessRotation()
    {
        //float pitchDueToPosition = _rigidbody.velocity.y * positionPitchFactor;
        //float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = _rigidbody.velocity.y *-0.4f;
        float yaw = 0f;
        float roll = xThrow * controlRollFactor;
        Ship.transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed);
    }
 

    private void Jump()
    {
        if (_jump)
        {
            _rigidbody.velocity = Vector3.up * _jumpmultiplier;
            _jump = false;
        }
    }
}
