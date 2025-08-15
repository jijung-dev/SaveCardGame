using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject phantomBase;
    [SerializeField]
    private GameObject allyBase;
    [SerializeField]
    private GameObject cardBase;
    public void SetUp()
    {
        var phantoms = EntityManager.GetAllPhantom();
        for (int i = 0; i < phantoms.Length; i++)
        {
            Spawn(allyBase, phantoms[i].data, phantoms[i].celPosition);
            phantoms[i].Destroy();
        }
    }
    public Card SpawnCard(CardData data)
    {
        var card = Instantiate(cardBase, Reference.deck.transform).GetComponent<Card>();
        card.SetData(ScriptableObject.Instantiate(data));
        return card;
    }
    public void SpawnPhantom(EntityData data, GameTile tile)
    {
        Spawn(phantomBase, data, tile);
    }
    public void Spawn(GameObject baseObject, EntityData data, GameTile tile)
    {
        var entity = Instantiate(baseObject, (Vector3Int)tile.celPosition, Quaternion.identity, transform).GetComponent<Entity>();
        entity.data = data;
    }
    public void Spawn(EntityWaveData data)
    {
        var possiblePosition = data.possiblePosition.ToList();
        var possibleEntity = data.possibleEntity.ToList();
        for (int i = 0; i < data.spawnCount; i++)
        {
            var ranPos = possiblePosition.RandomItem();
            var ranEntity = possibleEntity.RandomItem();

            Spawn(data.baseObject, ranEntity, ranPos);
            possiblePosition.Remove(ranPos);
        }
    }
}
