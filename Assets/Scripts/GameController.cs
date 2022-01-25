using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController GC;

    public List<Planet> planets = new List<Planet>();
    public bool simulate = false;
    public float G = 0.0001f;
    public float simSpeed = 10;
    public IEnumerator SimulatePlanets()
    {
        while (true)
        {
            if (simulate)
            {
                foreach (var planet in planets)
                {
                    if (!planet.isStatic)
                    {
                        for (int i = 0; i < planets.Count; i++)
                        {
                            if (planets[i] != planet)
                            {
                                float dist = Vector3.Distance(planet.transform.position, planets[i].transform.position);
                                float forceStrength = (G * planet.mass * planets[i].mass) / dist;
                                Vector3 forceDirection = planets[i].transform.position - planet.transform.position;
                                planet.force += forceDirection * forceStrength;
                            }
                        }
                        planet.SimulateNextStep(Time.fixedDeltaTime * simSpeed);
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnValidate()
    {
        if (GC == null)
            GC = this;
    }

    private void Start()
    {
        planets = FindObjectsOfType<Planet>().ToList();
        if (GC == null)
            GC = this;
        StartCoroutine(SimulatePlanets());
    }

}
