using UnityEngine;

public class Reference : MonoBehaviourSingleton<Reference>
{
    public Deck _deck;
    public Player _player;
    public static Deck deck => instance._deck;
    public static Player player => instance._player;
}
