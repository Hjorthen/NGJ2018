using UnityEngine;

public class FollowCam : MonoBehaviour {

    [SerializeField]
    private bool DebugMode = false;

    public Transform FollowTarget;
    public Vector3 Offset = new Vector3(0, 1.25f, 2.0f);
    public float LerpSpeedFactor;
    public float ColliderRadius = 0.15f;

    enum RayCastDir
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    private bool prevEnvAdjusted = false;
    private static readonly float kRaycastLength = 0.05f;
    // Use this for initialization
    void Start () {
        if (FollowTarget == null)
        {
            Debug.Log("Missing target object for camera: " + gameObject.name, gameObject);
            this.enabled = false;
        }

        UpdatePosRotation(true);

    }

    // Update is called once per frame
    void Update () {
        UpdatePosRotation(false);
	}

    private void UpdatePosRotation(bool snap)
    {
        transform.position = new Vector3(FollowTarget.position.x, transform.position.y, transform.position.z);
        Vector3 relativePositionOffset = GetRelativePos(FollowTarget.position) + new Vector3(Offset.x, Offset.y, -Offset.z);
        transform.position = Vector3.Lerp(transform.position, transform.position + relativePositionOffset, snap ? 1 : Time.deltaTime * LerpSpeedFactor);

        Ray rayUp = new Ray(transform.position + (transform.up * ColliderRadius), transform.up);
        Ray rayDown = new Ray(transform.position + (-1 * transform.up * ColliderRadius), -1 * transform.up);
        Ray rayLeft = new Ray(transform.position + (-1 * transform.right * ColliderRadius), -1 * transform.right);
        Ray rayRight = new Ray(transform.position + (transform.right * ColliderRadius), transform.right);

        AdjustPositionOnSpaceAxis(rayUp , RayCastDir.Up, kRaycastLength);
        AdjustPositionOnSpaceAxis(rayDown, RayCastDir.Down, kRaycastLength);
        AdjustPositionOnSpaceAxis(rayLeft, RayCastDir.Left, kRaycastLength);
        AdjustPositionOnSpaceAxis(rayRight, RayCastDir.Right, kRaycastLength);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(GetRelativePos(FollowTarget.position)), snap ? 1 :Time.deltaTime * LerpSpeedFactor);
    }

    private bool AdjustPositionOnSpaceAxis(Ray ray, RayCastDir dir, float rayLength)
    {
        RaycastHit outHit;
        if (Physics.Raycast(ray, out outHit, kRaycastLength))
        {
            if (DebugMode)
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                Debug.Log("Ray hit " + outHit.transform.gameObject.name);
            }
            float neededOffset = Mathf.Abs(kRaycastLength - Vector3.Distance(outHit.point, ray.origin));

            Vector3 pos = transform.position;
            switch(dir)
            {
                case RayCastDir.Up:
                    pos = new Vector3(transform.position.x, transform.position.y - neededOffset, transform.position.z);
                    break;
                case RayCastDir.Down:
                    pos = new Vector3(transform.position.x, transform.position.y + neededOffset, transform.position.z);
                    break;
                case RayCastDir.Left:
                    pos = new Vector3(transform.position.x - neededOffset, transform.position.y, transform.position.z);
                    break;
                case RayCastDir.Right:
                    pos = new Vector3(transform.position.x + neededOffset, transform.position.y, transform.position.z);
                    break;
            }
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * LerpSpeedFactor);
            return true;
        }

        return false;
    }

    private Vector3 GetRelativePos(Vector3 target)
    {
        return target - transform.position;
    }
}
