using System;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private Image Image;
    private AlienData data;
    private Action<Alien> placeAlien;

    public Action OnDisableAction;

    public AlienData Data => data;

    public void Init(AlienData alienData, Action<Alien> placeAlien)
    {
        data = alienData;
        Image.sprite = data.Sprite;
        this.placeAlien = placeAlien;
    }

    private void OnDisable() => OnDisableAction?.Invoke();

    public void PlaceAlien() => placeAlien.Invoke(this);
}
