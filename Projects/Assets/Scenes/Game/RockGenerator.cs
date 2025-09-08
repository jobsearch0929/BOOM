using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockPrefab;

    void Start()
    {
        InvokeRepeating("GenRock", 1, 1);
    }

    void GenRock()
    {
        Instantiate(rockPrefab, new Vector3(Random.Range(-5.0f, 5f), 6, 0), Quaternion.identity); // -7~7‚ÌŠÔ‚Åƒ‰ƒ“ƒ_ƒ€
    }
}
