using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTapRandomiser : MonoBehaviour
{
    [SerializeField] private List<GameObject> WireTaps;
    [SerializeField] private List<GameObject> WireSections;

    private void Start()
    {
        InitTaps();
    }

    private void InitTaps()
    {
        var index = 0;
        for(int i = 0; i < WireSections.Count; i++)
        {
            WireSections[i].GetComponent<WireSection>().InitWireSection();

            index = Random.Range(0, WireTaps.Count);
            Debug.Log(index);
            WireSections[i].GetComponentInChildren<WireHead>()
                .SetConnector(WireTaps[index].transform);
            WireTaps[index].GetComponent<MeshRenderer>().material =
                WireSections[i].GetComponent<WireSection>().GetSocketMaterial();
            
            WireTaps.RemoveAt(index);
        }
    }
}
