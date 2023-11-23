using UnityEngine;

[RequireComponent (typeof(Alien))]
public class AlienMover : MonoBehaviour
{
    private Alien alien;

    private void Start()
    {
        alien = GetComponent<Alien>();
        alien.OnDisableAction += () => enabled = false;
    }

    private void Update()
    {
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
            transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            alien.PlaceAlien();
        }
    }

    private void UpdateForMobile()
    {
        if (Input.touchCount != 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                alien.PlaceAlien();
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                transform.position = Input.touches[0].position;
            }
        }
    }
}