using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    Transform mainCam;

    float rotationY = 0.0f;

    public float sansiblityX = 15.0f;
    public float sansiblityY = 15.0f;
    public float moveSpeed = 15f;

    //public GameObject bullet;

    RaycastHit rayHit;
    int layerMask;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mainCam = GetComponentInChildren<Camera>().transform;

        layerMask = 1 << LayerMask.NameToLayer("Enemy");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float rotationX = mainCam.localEulerAngles.y + Input.GetAxis("Mouse X") * sansiblityX;

        rotationY += Input.GetAxis("Mouse Y") * sansiblityY;
        rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f);

        mainCam.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        if (Input.GetKey(KeyCode.W))
            rigid.velocity = (new Vector3(mainCam.forward.x, 0f, mainCam.forward.z) * moveSpeed);
        else if (Input.GetKey(KeyCode.S))
            rigid.velocity = (new Vector3(-mainCam.forward.x, 0f, -mainCam.forward.z) * moveSpeed);
        else if (Input.GetKey(KeyCode.A))
            rigid.velocity = (new Vector3(-mainCam.right.x, 0f, -mainCam.right.z) * moveSpeed);
        else if (Input.GetKey(KeyCode.D))
            rigid.velocity = (new Vector3(mainCam.right.x, 0f, mainCam.right.z) * moveSpeed);

        Debug.DrawRay(transform.position, mainCam.forward * 10000f, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, mainCam.forward, out rayHit, 10000f, layerMask))
                rayHit.transform.gameObject.GetComponent<Enemy>().PlayerHitEnemy();         
        }

    }

    //public float sansiblityX = 15.0f;
    //public float sansiblityY = 15.0f;
    //public float moveSpped = 15f;

    public void SetMouseX(float _xSense) { sansiblityX = _xSense; }
    public void SetMouseY(float _ySense) { sansiblityY = _ySense; }
    public void SetMoveSpeed (float _moveSpeed) { moveSpeed= _moveSpeed; }
    public float GetMouseX() { return sansiblityX; }
    public float GetMouseY() { return sansiblityY; }
    public float GetMoveSpeed() { return moveSpeed; }
}
