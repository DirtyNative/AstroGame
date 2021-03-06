using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetInstantiator : MonoBehaviour
{
    [Header("Planet Prefabs")]
    public List<GameObject> VolcanoPlanets = new List<GameObject>();
    public List<GameObject> DesertPlanets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private PlanetDto DeserializeJson(string json)
    {
        return JsonUtility.FromJson<PlanetDto>(json);
    }

    public void Instantiate(string json)
    {
        var instance = DeserializeJson(json);

        var planet = InstantiatePlanet(instance.PlanetPrefabName, instance.PlanetType);

    }

    private GameObject InstantiatePlanet(string prefabName, PlanetType planetType)
    {
        switch (planetType)
        {
            case PlanetType.Volcano:
                return Instantiate(VolcanoPlanets.FirstOrDefault(x => x.name == prefabName));
            default:
                throw new NotImplementedException($"PlanetType {planetType} is not implemented yet");
        }
        
    }
}
