using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camera;
    CharacterMovement player;
    public float followDistance;
    public float cameraLerpSpeed;
    public Vector3 cameraOffset;

    private void Start()
    {
        player = FindObjectOfType<CharacterMovement>();
    }
    void LateUpdate()
    {
        if (RangeCheck())
        {
            if (camera.transform.position != new Vector3(player.transform.position.x, player.transform.position.y, -1))
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, player.transform.position + cameraOffset
                    , cameraLerpSpeed * Time.deltaTime);
            }
        }   
    }
    bool RangeCheck()
    {
        return Vector3.Distance(player.transform.position + cameraOffset, camera.transform.position) > followDistance;
    }
}
