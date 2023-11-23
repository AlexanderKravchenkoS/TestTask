using System;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private Image Image;
    private AlienData data;
    private Action<Alien> placeAlien;

    public AlienData Data => data;

    public void Init(AlienData alienData, Action<Alien> placeAlien)
    {
        data = alienData;
        Image.sprite = data.Sprite;
        this.placeAlien = placeAlien;
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
            placeAlien.Invoke(this);
        }
    }

    private void UpdateForMobile()
    {
        if (Input.touchCount != 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                placeAlien.Invoke(this);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                transform.position = Input.touches[0].position;
            }
        }
    }
}
