using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Trail : MonoBehaviour
{
    public GameObject target;

    public Queue<Vector3> steps;
    public int length = 100;
    [Range(0,1000)] public float resolution = 100;
    LineRenderer line;

    public Gradient gradient;

    private void Start()
    {
        if(target != null)
        {
            line = GetComponent<LineRenderer>();
            line.colorGradient = gradient;
            steps = new Queue<Vector3>(length);
            StartCoroutine(BeginTrail());
        }
        
    }

    private IEnumerator BeginTrail()
    {
        while (true)
        {
            if (steps.Count == length)
            {
                steps.Dequeue();
            }
            if (GameController.GC.simulate)
            {
                steps.Enqueue(target.transform.position);
                line.positionCount = steps.Count;
                line.SetPositions(steps.ToArray());
            }
            yield return new WaitForSeconds(1 / resolution);
        }
    }

}
