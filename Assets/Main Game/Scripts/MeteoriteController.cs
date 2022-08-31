using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] MeteoriteSettings meteoriteSettings;
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.angularVelocity = MainTools.GetRandomVector3(-Vector3.one, Vector3.one) * meteoriteSettings.AngularVelocity;
        scale = transform.localScale;
    }
    Vector3 scale;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = scale * meteoriteSettings.MeteoriteSizeMultiplier;
    }
}
