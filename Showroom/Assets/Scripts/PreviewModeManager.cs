using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PreviewModeManager")]
public class PreviewModeManager : ScriptableObject
{
    //These bools will allow other scripts to run their animations
    public bool LightsAnimation = false;
    public bool CollumnsAnimation = false;

}

public static class RunMode
{
    public static bool Develop = false;
}
