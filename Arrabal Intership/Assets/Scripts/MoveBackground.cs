using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    void Update()
    {
		transform.position = new Vector3(Input.mousePosition.x / 800, transform.position.y, transform.position.z);
    }
}
