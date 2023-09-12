//obsolete script. Will be revised later.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeManager : MonoBehaviour
{
    public ThemeEngine[] themeEngine;

    [System.Serializable]
    public class ThemeEngine
    {

        public string themeTitle; //for inspector

        [Tooltip("The objects to be assigned by pooling")]
        public poolThemeObject[] PoolThemeObjects;

        [Tooltip("The objects will be assigned 1 time when theme is changed\n it's called when the game is started also")]
        public themeObjects[] ThemeObjects;

        //randomly called objects
        [System.Serializable]
        public class poolThemeObject
        {
            [Tooltip("The object will be assigned")]
            public GameObject PoolingObject;

            [Tooltip("The objects will assign according to this ratios")]
            public int RatioOfObject;
        }

        //only one time called objects when theme is changed
        [System.Serializable]
        public class themeObjects
        {
            [Tooltip("The object will be assigned 1 time when theme is changed\n it's called when the game is started also")]
            public GameObject ThemeObject;

            [Tooltip("The objects will assign according to this ratios")]
            public Vector3 ThemeObjectLocations;
        }

    }
}
