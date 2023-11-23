using UnityEngine;

public class InputService : MonoBehaviour
{
    private Alien currentTarget;

    public void SetTarget(Alien alien)
    {
        currentTarget = alien;
#if UNITY_EDITOR
        UpdatePosition(Input.mousePosition);
#endif
#if !UNITY_EDITOR
        UpdatePosition(Input.touches[0].position);
#endif
    }

    private void Update()
    {
        if (currentTarget == null) return;

#if UNITY_EDITOR
        UpdateForEditor();
#endif
#if !UNITY_EDITOR
        UpdateForMobile()
#endif
    }

    private void UpdateForEditor()
    {
        if (Input.GetMouseButton(0))
        {
            UpdatePosition(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentTarget.PlaceAlien();
            currentTarget = null;
        }
    }

    private void UpdateForMobile()
    {
        if (Input.touchCount != 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                currentTarget.PlaceAlien();
                currentTarget = null;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                UpdatePosition(Input.touches[0].position);
            }
        }
    }

    private void UpdatePosition(Vector3 positionInPixels)
    {
        var position = Camera.main.ScreenToWorldPoint(positionInPixels);
        position.z = 0;
        currentTarget.transform.position = position;
    }

}
