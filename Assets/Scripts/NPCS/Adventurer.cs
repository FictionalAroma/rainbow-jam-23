



using DataObjects;
using NPCS;

public class Adventurer
{
    AdventurerData AdventurerData { get; set; }
    AdventurerAction AdventurerAction { get; set; }
    public Adventurer(AdventurerData data)
    {
        AdventurerData = data;
    }
    public void Tick()
    {
        switch (AdventurerData.State)
        {
            
            case NPCState.Busy:
                AdventurerAction.TicksLeft--;
                if (AdventurerAction.TicksLeft<=0)
                {
                    AdventurerData.State = NPCState.Idle;

                }
                break;
            default: break;

        }
        

        
    }

}