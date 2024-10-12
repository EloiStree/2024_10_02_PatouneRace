using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatouneSecretCodeMono : MonoBehaviour
{
   
    [ContextMenu("Turn on Patoune")]
    public void TurnOnPatoune() {
        StaticTurnOnPatoune();
    }

    [ContextMenu("Turn off Patoune")]
    public void TurnOffPatoune() {
        StaticTurnOffPatoune();
    }

    public static void StaticTurnOnPatoune() {

        HiddenPatouneItemMono[] checkpointRaceMono =
            GameObject.FindObjectsByType<HiddenPatouneItemMono>(
                FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (HiddenPatouneItemMono item in checkpointRaceMono) {
            item.DisplayPatoune();
        }

    }

   
    public static void StaticTurnOffPatoune() {
        HiddenPatouneItemMono[] checkpointRaceMono =
            GameObject.FindObjectsByType<HiddenPatouneItemMono>(
                FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (HiddenPatouneItemMono item in checkpointRaceMono) {
            item.HidePatoune();
        }

    }
}
