using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        transform.Rotate(0, 360 * speed * Time.deltaTime,0);
    }
}
