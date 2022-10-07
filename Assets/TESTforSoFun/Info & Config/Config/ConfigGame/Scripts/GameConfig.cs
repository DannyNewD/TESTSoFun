using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Space]
    [Header("Config")]
    [SerializeField] private string _nameConfig;
    public string nameConfig => _nameConfig;

    [Space]
    [SerializeField] private int _numberSphers;
    public int numperSphers => _numberSphers;

    [Space]
    [SerializeField] private Color32[] _colors;
    public Color32[] colors => _colors;

    [Space]
    [SerializeField] [Range(0, 20)] private float _impulsPower;
    public float impulsPover => _impulsPower;
}
