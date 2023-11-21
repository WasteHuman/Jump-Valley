#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

partial class CubeSO : ScriptableObject, ISerializationCallbackReceiver
{
    public GameObject cube;

    private bool _isErrorSend;

    public void OnAfterDeserialize()
    {

    }

    public void OnBeforeSerialize()
    {
        if (cube != null)
        {
            if (CubeName.Equals(cube.name) == false)
            {
                CubeName = cube.name;
                EditorUtility.SetDirty(this);
                _isErrorSend = false;
                Debug.Log("Changed");
            }
        }
        else
        {
            if (_isErrorSend == false)
            {
                _isErrorSend = true;
                CubeName = string.Empty;
                Debug.Log("No set cube");

            }
        }
    }
}
#endif