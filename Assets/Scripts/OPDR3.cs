using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using TMPro;

public class OPDR3 : MonoBehaviour
{
    bool FromAToB = true;
    Vector3 differenceVector;
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform Player;
    float distance;
    Vector3 direction;
    [SerializeField] TextMeshProUGUI stopwatch;
    float time = 0;
    float duration;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        differenceVector = B.position - A.position;
        distance = differenceVector.magnitude;
        Player.position = A.position;
        duration = distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        //direction = differenceVector.normalized;
        duration = distance / speed;
        time += Time.deltaTime;
        stopwatch.text = time.ToString("F3");
        
        if (FromAToB)
        {
            direction = (B.position - A.position).normalized;
        }
        else
        {
            direction = (A.position - B.position).normalized;
        }
        Player.position += direction * speed * Time.deltaTime;
        if (time > duration)
        {
            time = 0;
            Debug.Log("ja");
            //inverteer de variabele FromAtoB
            FromAToB = !FromAToB;
        }
    }
}
