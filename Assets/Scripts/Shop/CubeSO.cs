using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeData", menuName = "ScriptableObject/CubeData")]
public partial class CubeSO : ScriptableObject
{
    public string CubeName;

    public GameObject mainCube;

    private void Awake()
    {
        
    }
}
