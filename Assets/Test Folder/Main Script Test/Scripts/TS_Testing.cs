using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TS_Testing : MonoBehaviour
{
    [SerializeField] GameObject g;
    [SerializeField] Vector3 vector;
    KeyCode keys = KeyCode.A;

[EButton]
    void testME()
    {
        print(Random.value);
    }
    abstract class deneme3
    {
        public abstract string name { get; set; }
        public abstract Vector3[] GunPositions { get; set; }
        public abstract float FlyingSpeed { get; set; }
        protected virtual void Fly() { }

    }
    class deneme4 : deneme3
    {
        public override string name { get => name; set { } }
        [SerializeField] private Vector3[] gunPositions;
        public override Vector3[] GunPositions { get { return gunPositions; } set { } }
        [SerializeField] private float flyingSpeed;
        public override float FlyingSpeed { get => flyingSpeed; set => flyingSpeed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
