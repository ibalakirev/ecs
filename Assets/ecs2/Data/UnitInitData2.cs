using UnityEngine;

[CreateAssetMenu]

public class UnitInitData2 : ScriptableObject
{
    [field: SerializeField] public UnitActor2 UnitPrefab { get; private set; }
    [field: SerializeField] public string Name { get; private set; } = "UnitName";
}
