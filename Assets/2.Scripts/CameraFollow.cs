using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // This script makes the camera follow a target GameObject in the scene.

    [SerializeField] GameObject target;


    
    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3(0, 0, -10);
    }
}
