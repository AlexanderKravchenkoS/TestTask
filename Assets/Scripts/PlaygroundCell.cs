using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlaygroundCell : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void PlaceAlien(AlienData data)
    {
        ChangeSprite(data.Sprite);
    }

    private void ChangeSprite(Sprite sprite)
    {
        image.sprite = sprite;
        image.color = Color.white;
    }
}