using UnityEngine;
using Characters;

namespace Items
{
	public enum ItemType { Weapon, Mobility, Utility }
	public enum SkillType { Attack, StatChange }
	public enum TargetingType { Self, Area, Projectile }

	public abstract class Item : MonoBehaviour
	{
		[SerializeField] protected ItemType itemType;
		[SerializeField] protected SkillType[] skillType;
		[SerializeField] protected TargetingType targetingType;
		[SerializeField] protected CharacterStats itemStats;

		public abstract void OnUse();

		public ItemType GetItemType() { return itemType; }

		public SkillType[] GetSkillType() { return skillType; }

		public TargetingType GetTargetingType() { return targetingType; }

		public CharacterStats GetItemStats() { return itemStats; }
	}
}