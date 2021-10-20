using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: �������������� ���, �������� �������� ��������� ��������
public class Adjuster : MonoBehaviour
{
    [Space]
    [SerializeField]
    List<Artboard> artboards;
    public List<Artboard> Artboards
    {
        get
        {
            return artboards;
        }
    }

    [Space]
    [SerializeField]
    List<GameObject> objects;
    public List<GameObject> Objects
    {
        get
        {
            return objects;
        }
    }

    private void Awake()
    {
        //ArrangeObjects(); //TODO: ����� ��������� ����� � ������-���������
    }

    public void ArrangeObjects()
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            Artboard tempArtboard = Artboards[Random.Range(0, Artboards.Count)];

            Objects[i].transform.localPosition = new Vector3(Random.Range(tempArtboard.StartBoundary.x, tempArtboard.EndBoundary.x),
                Random.Range(tempArtboard.StartBoundary.y, tempArtboard.EndBoundary.y),
                Random.Range(tempArtboard.StartBoundary.z, tempArtboard.EndBoundary.z));
        }
    }
}
