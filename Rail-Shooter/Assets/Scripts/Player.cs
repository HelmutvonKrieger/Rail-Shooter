using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;

    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = -9.44f;
    [SerializeField] float controlRollFactor = -30f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleTranslation();
        HandleRotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning(collision.collider);
    }

    private void HandleTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = -yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }

    private void HandleRotation()
    {
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControlThrow = -yThrow * controlPitchFactor;
        float yawFromPostion = transform.localPosition.z + positionYawFactor;
        //float yawFromControlThrow = zThrow * controlYawFactor;
        //float rollFromPostion = transform.localPosition.x * positionRollFactor;
        float rollFromControlThrow = xThrow * controlRollFactor;

    transform.localRotation = Quaternion.Euler(
        pitchFromPosition + pitchFromControlThrow,
        yawFromPostion,
        rollFromControlThrow);
    }
}
