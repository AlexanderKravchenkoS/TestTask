using System;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer;
    private AlienData data;
    private Action<Alien> placeAlien;

    public Action OnDisableAction;

    public AlienData Data => data;

    public void Init(AlienData alienData, Action<Alien> placeAlien)
    {
        data = alienData;
        renderer.sprite = data.Sprite;
        this.placeAlien = placeAlien;
    }
    
    public void PlaceAlien() => placeAlien.Invoke(this);
}
