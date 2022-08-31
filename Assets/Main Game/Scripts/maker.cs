using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// maker maker chicken shaker
[RequireComponent(typeof(MAIN_TRANSPORTER_SCRIPT))]
public class maker : MonoBehaviour
{
    /// <summary>
    /// for adding or removing from allStuffs list
    /// </summary>
    MAIN_TRANSPORTER_SCRIPT mAIN_TRANSPORTER_SCRIPT;

    /// <summary>
    /// theDistance of player to endOfRoad
    /// </summary>
    [SerializeField] private float theDistance;

    public float extraDestination = 100f;

    public themeManager ThemeManager;

    /// <summary>
    /// to teleport the player
    /// </summary>
    public Transform player;

    bool areSignedImmediatelyObjectsSigned=false;

    int previousThemeNo = -1;
    int themeNo = 0;

    int choosenObjectNumber=0;
    bool isFirst = true;

    /// <summary>
    /// the z position of end of road
    /// </summary>
    [HideInInspector] public float endOfRoad = 0f;

    [SerializeField] bool isBehindIt;
    bool isRunned = false;
    [SerializeField] List<GameObject> _theObjeThatIsInTheLocatıonOfPlayer = new List<GameObject>();
    //the list that will be sorted. but must be eliminated
    [SerializeField] List<GameObject> _sortedList = new List<GameObject>();

    void Start()
    {
        mAIN_TRANSPORTER_SCRIPT = GetComponent<MAIN_TRANSPORTER_SCRIPT>();
        GameObject _choosenTwoObject;
        while (endOfRoad < 4000)
        {
            //choose a road and put into the scene
            _choosenTwoObject = choosenObject(); 
            float lenght = _choosenTwoObject.transform.GetComponent<BoxCollider>().size.z;
            mAIN_TRANSPORTER_SCRIPT.allStuffs.Add(
            Instantiate(_choosenTwoObject, new Vector3(0, 0, 0 + endOfRoad+ lenght / 2 ), Quaternion.identity)
            );
            //the reason of choicing of collider instead of scale is that sometimes devoloper can want start the object in a little back or more ahead
            endOfRoad += lenght;
        }
        signingImmediately();
        _theObjeThatIsInTheLocatıonOfPlayer = theObjectListThatIsInTheLocatıonOfPlayer();
    }

    void Update()
    {
        if ( player.transform.position.z > theObjectThatIsInTheLocatıonOfPlayer(isBehindIt))
        {
            //making new objects:
            //btw i am working to use different names on every varaible for not confusing with other varaibles. for example i cant use "i" because the choosenObject() has "i" in its for function
            
            int _new_object_count = 0;
            //theDistance of player to endOfRoad must stay at about 4000
            while (_new_object_count < ( theDistance < 4000 ?  _theObjeThatIsInTheLocatıonOfPlayer.Count()+1 : _theObjeThatIsInTheLocatıonOfPlayer.Count() - 1) )
            {
            GameObject _choosenOneObject = choosenObject();

                float lenght = _choosenOneObject.transform.GetComponent<BoxCollider>().size.z;
                mAIN_TRANSPORTER_SCRIPT.allStuffs.Add(
                Instantiate(_choosenOneObject, new Vector3(0, 0, endOfRoad + (lenght / 2)), Quaternion.identity)
                );
                endOfRoad += lenght;
                _new_object_count++;
            }
            //destroying old objects:
            foreach (GameObject _objectToBeExited in _theObjeThatIsInTheLocatıonOfPlayer)
            {
                mAIN_TRANSPORTER_SCRIPT.rfl(_objectToBeExited);
                Destroy(_objectToBeExited);
            }
            _theObjeThatIsInTheLocatıonOfPlayer = theObjectListThatIsInTheLocatıonOfPlayer();

            theDistance = endOfRoad - player.transform.position.z;
        }
    }

    GameObject choosenObject()
    {
        //ilk defa atama yapılıyorsa ilk obje olan normal road'tan atama yapılsın
        if (isFirst)
        {
            if (choosenObjectNumber < 10)
            {
                choosenObjectNumber++;
                if (choosenObjectNumber == 10) { isFirst = false; }
                return ThemeManager.themeEngine[themeNo].themeObjectsList[themeNo];
            }
        }
        else
        {
            int _choosen_ratio;
            int _top_ratio = 0;
            int _ratio_atm = 0;
            int _lenght_of_list;
            //definings of varaibles:
            _lenght_of_list = ThemeManager.themeEngine[themeNo].ratioOfObjects.Length;

            for (int i = 0; i < _lenght_of_list; i++)
            {
                _top_ratio += ThemeManager.themeEngine[themeNo].ratioOfObjects[i];
            }
            _choosen_ratio = Random.Range(0, _top_ratio);
            for (int i = 0; i < _lenght_of_list; i++)
            {
                if (_ratio_atm <= _choosen_ratio && _choosen_ratio < _ratio_atm + ThemeManager.themeEngine[themeNo].ratioOfObjects[i])
                {
                return ThemeManager.themeEngine[themeNo].themeObjectsList[i];
                }
                _ratio_atm += ThemeManager.themeEngine[themeNo].ratioOfObjects[i];
            }

        }
        return null;
    }

    void signingImmediately()
    {
        if (!areSignedImmediatelyObjectsSigned)
        {
            if (previousThemeNo != -1 && ThemeManager.themeEngine[previousThemeNo].signedImmediately.Count != 0)
            {
                foreach (GameObject _to_be_exited in ThemeManager.themeEngine[previousThemeNo].signedImmediately)
                {
                    mAIN_TRANSPORTER_SCRIPT.rfl(_to_be_exited);
                    Destroy(_to_be_exited);
                }
            }
            for (int i = 0; i < ThemeManager.themeEngine[themeNo].signedImmediately.Count; i++)
            {
                mAIN_TRANSPORTER_SCRIPT.allStuffs.Add(ThemeManager.themeEngine[themeNo].signedImmediately[i]);
                Instantiate(ThemeManager.themeEngine[themeNo].signedImmediately[i], ThemeManager.themeEngine[themeNo].signedImmediatelyLocations[i], Quaternion.identity);
            }
            areSignedImmediatelyObjectsSigned = true;
        }
    }

    List<GameObject> theObjectListThatIsInTheLocatıonOfPlayer()
    {
        _sortedList.Clear();

        // the list that will be returned
        List<GameObject> _newlist    = new List<GameObject>();

        foreach (GameObject _stuff in mAIN_TRANSPORTER_SCRIPT.allStuffs)
        {
            //sim = signed immediately objects
            bool _is_stuff_in_sim = false;
            if(ThemeManager.themeEngine[themeNo].signedImmediately != null)
                foreach (GameObject _SIM in ThemeManager.themeEngine[themeNo].signedImmediately)
                {
                    if (_stuff == _SIM)
                    {
                        _is_stuff_in_sim = true;
                        break;
                    }
                }
            if (!_is_stuff_in_sim)
            {
                _sortedList.Add(_stuff);
            }

        }

        //sorting

/* değişiklikler:
 * for (int _a = 0; _a < i; _a++) -> for (int _a = 0; _a < i-1; _a++) çünkü i'inci obje playerin önündedir ama buna rağmen isBehindIt = true.
 * yukarıdaki değişikliği iptal ettim. bunu yapınca sorunlar çıktı.
 */
        _sortedList = _sortedList.OrderBy(o => o.transform.position.z).ToList();
        
        for(int i = 0; i < _sortedList.Count; i++)
        {
            if (player.position.z < _sortedList[i].transform.position.z && i != 0)
            {
                for (int _a = 0; _a < i; _a++)
                {
                    _newlist.Add(_sortedList[_a]);
                }
                isBehindIt = true;
                break;
                
            }
            if (player.position.z < _sortedList[i].transform.position.z && i == 0)
            {
                _newlist.Add(_sortedList[i]);
                isBehindIt = false;
                break;
            }
        }
        return _newlist;
    }

    float theObjectThatIsInTheLocatıonOfPlayer(bool _isbehindit)
    {
        if (_isbehindit)
        {
            return _theObjeThatIsInTheLocatıonOfPlayer[_theObjeThatIsInTheLocatıonOfPlayer
                .Count - 1].transform.GetComponent<BoxCollider>().size.z 
                + _theObjeThatIsInTheLocatıonOfPlayer[_theObjeThatIsInTheLocatıonOfPlayer
                .Count - 1].transform.position.z
                + extraDestination
                ;
        }
        else
        {
            return _theObjeThatIsInTheLocatıonOfPlayer[0].transform.
                GetComponent<BoxCollider>().size.z
                + _theObjeThatIsInTheLocatıonOfPlayer[0].transform.position.z
                + extraDestination
                ;
        }
    }
}
