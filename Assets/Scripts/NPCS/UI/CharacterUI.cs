using GameMenu;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.NPCS.UI
{
    public class CharacterUI : IngameUIBase<QuestSheet>
    {
        [SerializeField] TextMeshProUGUI nameText, level, npcClass, race, strength, dexterity, constitution, intelligence, wisdom, charisma;
        [SerializeField] TextMeshProUGUI healthPoints;
        [SerializeField] TextMeshProUGUI healthPointsMax;
        [SerializeField] TextMeshProUGUI armorClass;
        [SerializeField] TextMeshProUGUI traits, flaws, ideals, skills;


        protected override void Populate(QuestSheet characterSheet)
        {
            if (nameText != null) nameText.text = $"{characterSheet.firstName} + {characterSheet.lastName}";
            if (level != null) level.text = characterSheet.level.ToString();
            if (npcClass != null)
                npcClass.text = characterSheet.npcClass;
            if (race != null)
                race.text = characterSheet.race.ToString();
            if (strength != null)
                strength.text = characterSheet.strength.ToString();
            if (dexterity != null)
                dexterity.text = characterSheet.dexterity.ToString();
            if (constitution != null)
                constitution.text = characterSheet.intelligence.ToString();
            if (intelligence != null)
                intelligence.text = characterSheet.intelligence.ToString();
            if (wisdom != null)
                wisdom.text = characterSheet.wisdom.ToString();
            if (charisma != null)
                charisma.text = characterSheet.charisma.ToString();
            if (healthPoints != null)
                healthPoints.text = characterSheet.healthPoints.ToString();
            if (healthPointsMax != null)
                healthPointsMax.text = characterSheet.healthPointsMax.ToString();
            if (armorClass != null)
                armorClass.text = characterSheet.armorClass.ToString();
            if (traits != null)
                traits.text = characterSheet.neg_traits.ToString() + characterSheet.pos_traits.ToString();
            if (flaws != null)
                flaws.text = characterSheet.flaws.ToString();
            if (ideals != null)
                ideals.text = characterSheet.ideals.ToString();
            if (skills != null)
                skills.text = characterSheet.skills.ToString();

        }

    }
}