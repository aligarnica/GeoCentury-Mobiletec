using System;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller3DExample : MonoBehaviour
{
    public const float ROTATE_SPEED = 15f;

    public float movementSpeed = 5f;


    public CNAbstractController MovementJoystick;

    private CharacterController _characterController;
    private Transform _mainCameraTransform;
    private Transform _transformCache;
    private Transform _playerTransform;
	public Transform _playersetuptrans;
	public Transform _robot1;
	public Transform _robot2;
	public Transform _robot3;
	public Transform _robot4;
	public Transform _robot5;
	private HashID hash;
	private Animator anim;
	public Button X;


	void Awake ()
	{
		// Setting up the references.
		anim = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<HashID>();
		
		// Set the weight of the shouting layer to 1.
	
	}

    void Start()
    {
        // You can also move the character with an event system
        // You MUST CHOOSE one method and use ONLY ONE a frame
        // If you wan't the event based control, uncomment this line
        // MovementJoystick.JoystickMovedEvent += MoveWithEvent;

        _characterController = GetComponent<CharacterController>();
        _mainCameraTransform = Camera.main.GetComponent<Transform>();
        _transformCache = GetComponent<Transform>();
		_playerTransform = _transformCache.FindChild("MotusMan_v2");


    }

    
    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(
            MovementJoystick.GetAxis("Horizontal"),
            0f,
            MovementJoystick.GetAxis("Vertical"));
		anim.SetFloat(hash.speedFloat,MovementJoystick.GetAxis("Vertical"));
		_playersetuptrans.localPosition = new Vector3 (_playersetuptrans.localPosition.x, 6.99f, _playersetuptrans.localPosition.z);

		       CommonMovementMethod(movement);
		int ver=0;
		if (Vector3.Distance (_robot1.localPosition, _playersetuptrans.localPosition) < 5f) {
			try{
			X.enabled = true;
			X.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
			X.GetComponentInChildren<Text> ().color = Color.white;
			}
			catch{
				
			}
		} else {
			ver=ver+1;
		}
		if (Vector3.Distance (_robot2.localPosition, _playersetuptrans.localPosition) < 5f) {
			try{
			X.enabled = true;
			X.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
			X.GetComponentInChildren<Text> ().color = Color.white;
			}
			catch{

			}
			
		} else {
			ver=ver+1;
		}
		if (Vector3.Distance (_robot3.localPosition, _playersetuptrans.localPosition) < 5f) {
			try{
			X.enabled = true;
			X.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
			X.GetComponentInChildren<Text> ().color = Color.white;
			}
			catch{
				
			}
		} else {
			ver=ver+1;
		}
		if (Vector3.Distance (_robot4.localPosition, _playersetuptrans.localPosition) < 5f) {
			try{
			X.enabled = true;
			X.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
			X.GetComponentInChildren<Text> ().color = Color.white;
			}
			catch{
					
				}
		} else {
			ver=ver+1;
		}
		if (Vector3.Distance (_robot5.localPosition, _playersetuptrans.localPosition) < 3f) {
			try{
			X.enabled = true;
			X.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);
			X.GetComponentInChildren<Text> ().color = Color.white;
			}
			catch{
				
			}
		} else {
			ver=ver+1;
		}
		Debug.Log (ver);
		if (ver == 5) {
			X.enabled = false;
			X.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			X.GetComponentInChildren<Text>().color = Color.clear;
		}
    }


    private void MoveWithEvent(Vector3 inputMovement)
    {
        var movement = new Vector3(
            inputMovement.x,
            0f,
            inputMovement.y);

		CommonMovementMethod(movement);
    }

    private void CommonMovementMethod(Vector3 movement)
    {
        movement = _mainCameraTransform.TransformDirection(movement);
        movement.y = 0f;
        movement.Normalize();
		FaceDirection(movement);

		_characterController.Move(movement * movementSpeed * Time.deltaTime);
    }

    public void FaceDirection(Vector3 direction)
    {
        StopCoroutine("RotateCoroutine");
        StartCoroutine("RotateCoroutine", direction);
    }

    IEnumerator RotateCoroutine(Vector3 direction)
    {
        if (direction == Vector3.zero) yield break;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        do
        {
            _playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation, lookRotation, Time.deltaTime * ROTATE_SPEED);
            yield return null;
        }
        while ((direction - _playerTransform.forward).sqrMagnitude > 0.2f);
    }

}
