using System.Collections.Generic;
using UnityEngine;

public class Recources : MonoBehaviour
{
    [SerializeField]
    private List<AlienData> aliensRecources;
    [SerializeField]
    private CreateAlienButton createAlienButtonPrefab;
    [SerializeField]
    private Alien alienPrefab;

    private Dictionary<AlienType, AlienData> data;

    private void Awake()
    {
        data = new Dictionary<AlienType, AlienData>();
        foreach (var item in aliensRecources)
        {
            data[item.Type] = item;
        }
    }

    public AlienData GetAlienData(AlienType type) => data[type];

    public CreateAlienButton CreateAlienButton => createAlienButtonPrefab;

    public Alien AlienPrefab => alienPrefab;
}
