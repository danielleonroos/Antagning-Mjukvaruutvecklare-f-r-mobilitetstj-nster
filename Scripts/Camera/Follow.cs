﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform playerTarget;

    public PlayerController playerController;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    private float currentZoom = 10f;

    void Start()
    {

    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        if (playerController.isActiveAndEnabled)
        {
           offset.y = -6f;
            offset.z = 4f;
            pitch = 1f;
            transform.position = playerTarget.position - offset * currentZoom;
            transform.LookAt(playerTarget.position + Vector3.up * pitch);
        }
    }
}
