using UnityEngine;

public class CameraSizeFitter : MonoBehaviour
{
    [SerializeField]
    private Transform leftSide;
    [SerializeField]
    private Transform rightSide;

    void Start()
    {
        GetComponent<Camera>().orthographicSize = Vector3.Distance(leftSide.position, rightSide.position);
    }
}
