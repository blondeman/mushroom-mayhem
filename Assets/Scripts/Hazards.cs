using System.Collections;
using System.Reflection;
using StarterAssets;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    private Vector3 startPosition;
    public float deathLevel = -20;
    public CharacterController characterController;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update() {
        if (transform.position.y <= deathLevel) {
            Reset();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Checkpoint") {
            startPosition = other.transform.position;
        }   
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.tag == "Hazard") {
            Reset();
        }
    }

    private void Reset()
    {
        var tpc = GetComponent<ThirdPersonController>();
        tpc.enabled = false;
        characterController.enabled = false;

        transform.position = startPosition;
        tpc.ResetVelocity();

        StartCoroutine(ReEnableAfterFrame(tpc));
    }

    private IEnumerator ReEnableAfterFrame(ThirdPersonController tpc)
    {
        yield return null; // wait one frame
        yield return null; // wait a second frame to be safe
        characterController.enabled = true;
        tpc.enabled = true;
    }
}
