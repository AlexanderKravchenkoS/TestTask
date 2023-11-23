using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SelectButton), typeof(Image))]
public class CreateAlienButton : MonoBehaviour
{
    private AlienData alienData;
    private Action<AlienData> CreateAction;

    public void Init(AlienData data, Action<AlienData> createAction)
    {
        alienData = data;
        CreateAction = createAction;
        InitAlienImage();
        InitSelectButton();
    }

    private void InitAlienImage()
    {
        Image image = GetComponent<Image>();
        image.sprite = alienData.Sprite;
        image.preserveAspect = true;
    }

    private void InitSelectButton() => GetComponent<SelectButton>().Init(Create);

    private void Create()
    {
        CreateAction(alienData);
        Destroy(gameObject);
    }
}
