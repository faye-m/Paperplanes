using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoopPSystemScript : MonoBehaviour
{
    private ParticleSystem hoopPS;
    // Start is called before the first frame update
    void Start()
    {
        hoopPS = GetComponent<ParticleSystem>();
        hoopPS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
