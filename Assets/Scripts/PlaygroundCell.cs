using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlaygroundCell : MonoBehaviour
{
    [SerializeField]
    private Image Image;

    public void PlaceAlien(AlienData data)
    {
        ChangeSprite(data.Sprite);
    }

    private void ChangeSprite(Sprite sprite)
    {
        Image.sprite = sprite;
        Image.color = Color.white;
    }
}