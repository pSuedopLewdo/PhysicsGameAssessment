using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waypoint", menuName = "Waypoint")]
public class WaypointSO : ScriptableObject
{
    public GameObject[] transforms;
}
