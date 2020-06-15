using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    public int i;
    public float f;
    public string s;
    public Vector3 v;
    public Color c;
    public LayerMask l;
    public AnimationCurve a;

    public GameObject g;
    public Rigidbody r;
    public Transform t;

    public int[] array;
    public List<float> floats;
    public C cl;

    const string PrefName = "json test";

    [System.Serializable]
    public struct C
    {
        public int i;
        public float f;
    }

    private void OnValidate()
    {
        Debug.Log("OnValidate");
        //PlayerPrefs.SetInt("test int", 34);
        PlayerPrefs.SetString(PrefName, JsonUtility.ToJson(this, true));
        PlayerPrefs.Save();
    }

    private void OnDisable()
    {
        Debug.Log("OnDidable");
        PlayerPrefs.SetString(PrefName, JsonUtility.ToJson(this, true));
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(PrefName), this);
    }
}
