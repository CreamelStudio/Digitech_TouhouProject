using UnityEngine;

public class StaticMove : MonoBehaviour
{
    public Vector3 moveVec;
    public float speed;

    private void FixedUpdate()
    {
        transform.position += moveVec * speed;
    }
}
