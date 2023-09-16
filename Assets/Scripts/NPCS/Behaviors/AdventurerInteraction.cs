using Interactions;

namespace NPCS
{
	public class AdventurerInteraction : CharacterInteraction<Adventurer>
	{
		public Adventurer Data { get; set; }
		protected override Adventurer GetData() => Data;

		public override void LinkUI(UIManager manager)
		{
			this.menuToOpen = manager.CharacterUI;
		}
	}
}