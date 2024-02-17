using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject warning;
    float time = 0f;
    float laserWarningTime = 3f;
    float laserDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(time < laserWarningTime)
        {
            time += Time.deltaTime;
        }
        else if(time < laserWarningTime + laserDuration)
        {
            time += Time.deltaTime;
            warning.SetActive(false);
            laser.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
