using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float rotateSpeed;

    Vector3 moveDir;
    float rotateDir;
    float zoomScroll;
    float yRotate;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
        Rotate();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Move()
    {
        transform.parent.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.Self);
        transform.parent.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

    private void Rotate()
    {
        yRotate += rotateDir * rotateSpeed * Time.deltaTime;
        transform.parent.rotation = Quaternion.Euler(0, yRotate, 0);
    }

    private void OnRotate(InputValue value)
    {
        rotateDir = value.Get<float>();
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomSpeed * zoomScroll * Time.deltaTime, Space.Self);

    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }
}