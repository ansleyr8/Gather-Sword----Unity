using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // Player's transform
    private Vector3 updatedCameraPosition;

    public Vector2 cameraPositionOffset = new Vector2(8.66f, 2.5f); // Defaults, don't erase these.
    public Vector2 cameraRotationOffset = new Vector2(2.524f, 2.791f); // Defaults, don't erase these.

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target == null)
        {
            Debug.Log("Couldn't find player reference, did you tag the player with 'Player' tag?");
            return;
        }

        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + cameraPositionOffset.x, target.transform.position.z - cameraPositionOffset.y);
        this.transform.eulerAngles = new Vector3(67.139f, target.transform.eulerAngles.y + cameraRotationOffset.x, cameraRotationOffset.y);
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Lost reference from player to follow.");
            return;
        }

        updatedCameraPosition.x = target.transform.position.x;
        updatedCameraPosition.y = target.transform.position.y + cameraPositionOffset.x;
        updatedCameraPosition.z = target.transform.position.z - cameraPositionOffset.y;

        transform.position = updatedCameraPosition;
    }
}