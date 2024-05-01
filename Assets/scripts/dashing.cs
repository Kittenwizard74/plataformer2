using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class dashing : MonoBehaviour
{
    [Header ("Reference")]
    public Transform playerCam;
    public Transform orientacion;
    private Rigidbody rb;
    private movement pm;

    [Header("Dash")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    public float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.LeftShift;

    private Vector3 delayedForceToApply;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
        {
            Dash();
        }

        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }


    private void Dash()
    {
        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        pm.dashing = true;

        Vector3 forceToAply = orientacion.forward * dashForce + orientacion.up * dashUpwardForce;

        delayedForceToApply = forceToAply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;
    }
}
