using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
[Serializable]
public struct NpcIDInfo
{
    public Sprite photoID;
    public string name;
    public string age;
    public string idNumber;
    public string nationality;
    public string antivirus;
    public override string ToString()
    {
        return $"name: {name}\n age: {age}\n ID: {idNumber}\n nationality: {nationality}\n\n antivirus: {antivirus}";
    }
}
[Serializable]
public struct NpcVisaInfo
{
    public Sprite photoID;
    public string reason;
    public string name;
    public string age;
    public string idNumber;
    public string nationality;
    public string antivirus;
    public override string ToString()
    {
        return $"reason: {reason}\n name {name}\n age: {age}\n ID: {idNumber}\n nationality: {nationality}\n\n antivirus: {antivirus}";
    }
}
public class NPCInfo : MonoBehaviour
{
    public NpcIDInfo idInfo;
    public NpcVisaInfo visaInfo;
    public NpcIDInfo GetIDInfo()
    {
        return idInfo;
    }
    public NpcVisaInfo GetVisaInfo()
    {
        return visaInfo;
    }
}
