using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerDataSO", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public int damage = 20;
    public float explosionRadius = 5f;
}