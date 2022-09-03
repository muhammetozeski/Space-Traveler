using System;
using UnityEngine;

public class MeteoriteAreaCreator : MonoBehaviour
{
    [Serializable]
    class Meteorites
    {
        public GameObject Meteorite;
        public int Ratio;
        [HideInInspector] public ObjectPoolingSystem objPooling;
    }
    [SerializeField] GameSettings gameSettings;
    [SerializeField] BoxCollider Border;
    [SerializeField] int PoolCount;
    [SerializeField] Meteorites[] Meteorite;
    [SerializeField] Transform MeteoritesParent;

    int[] ratios;
    // Start is called before the first frame update
    void Awake()
    {
        Vector3 borderSize = Border.size;
        MainTools.V3SetX(ref borderSize, gameSettings.RoadWeight * 2);
        MainTools.V3SetY(ref borderSize, gameSettings.SpaceShipMaxTranslateHeight * 2);
        Border.size = borderSize;
        //TODO: set border size z with a serialized variable

        ratios = new int[Meteorite.Length];
        for (int i = 0; i < Meteorite.Length; i++)
        {
            ratios[i] = Meteorite[i].Ratio;
        }
        for (int i = 0; i < Meteorite.Length; i++)
        {
            Meteorite[i].objPooling = new ObjectPoolingSystem();
            Meteorite[i].objPooling.execudePoolingSystem(Meteorite[i].Meteorite, PoolCount);
        }
        MeteoritesParent.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        GetObjects(Meteorite, Border);
        MeteoritesParent.gameObject.SetActive(true);
    }

    void GetObjects(Meteorites[] meteorite, BoxCollider border)
    {
        for (int i = 0; i < PoolCount; i++)
        {
            GameObject _gameObject = meteorite[MainTools.RandomRatio(ratios)].objPooling.GetPool();
            _gameObject.transform.parent = MeteoritesParent; 
            _gameObject.transform.localPosition = MainTools.GetRandomPointFromBox(border);
            _gameObject.SetActive(true);
        }
    }
}
