using DG.Tweening;
using UnityEngine;

public class PlaygroundCell : MonoBehaviour
{
    private Alien alien;

    private const float PlaceDuration = 0.7f;

    public void PlaceAlien(Alien alien)
    {
        if (this.alien != null) Destroy(this.alien.gameObject);
        this.alien = alien;
        alien.transform.parent = transform;
        alien.transform.DOLocalMove(Vector3.zero, PlaceDuration);
    }
}