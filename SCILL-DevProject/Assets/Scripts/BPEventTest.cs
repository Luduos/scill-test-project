using SCILL;
using SCILL.Model;
using UnityEngine;

public class BPEventTest : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int levelIndex = SCILLBattlePassManager.Instance.GetCurrentBattlePassLevelIndex();
            Debug.Log($"Current LevelIndex {levelIndex}");
            switch (levelIndex)
            {
                case 0:
                    CollectMelons();
                    break;
                case 1:
                    DealPistolDamage();
                    break;
                case 2:
                    SearchCests();
                    break;
                case 3:
                    SniperRifleEliminiations();
                    break;
                case 4:
                    EliminateOpponentsInLavaFields();
                    break;
                case 5:
                    SearchSCILLLetters();
                    break;
                case 6:
                    FollowTheTreasureMap();
                    break;
            }
        }
    }

    private void CollectMelons()
    {
        EventMetaData metaData = new EventMetaData
        {
            amount = 5
        };
        SCILLManager.Instance.SendEventAsync("kill-enemy", "single", metaData);
    }

    private void DealPistolDamage()
    {
        EventMetaData metaData = new EventMetaData
        {
            damage_amount = 250,
            weapon_used = "pistol"
        };
        SCILLManager.Instance.SendEventAsync("deal-damage", "single", metaData);
    }

    private void SearchCests()
    {
        EventMetaData metaData = new EventMetaData
        {
            amount = 3,
            item_type = "chest"
        };
        SCILLManager.Instance.SendEventAsync("collect-item", "single", metaData);
    }

    private void SniperRifleEliminiations()
    {
        EventMetaData metaData = new EventMetaData
        {
            amount = 1,
            weapon_used = "sniper-rifle"
        };
        SCILLManager.Instance.SendEventAsync("kill-enemy", "single", metaData);
    }

    private void EliminateOpponentsInLavaFields()
    {
        EventMetaData metaData = new EventMetaData
        {
            amount = 2,
            map_name = "lava-fields"
        };
        SCILLManager.Instance.SendEventAsync("kill-enemy", "single", metaData);
    }

    private void SearchSCILLLetters()
    {
        EventMetaData metaData = new EventMetaData
        {
            amount = 3,
            item_type = "letter"
        };
        SCILLManager.Instance.SendEventAsync("collect-item", "single", metaData);
    }

    private void FollowTheTreasureMap()
    {
        EventMetaData metaData = new EventMetaData
        {
            mission_id = "treasure-map"
        };
        SCILLManager.Instance.SendEventAsync("pass-mission", "single", metaData);
    }
}