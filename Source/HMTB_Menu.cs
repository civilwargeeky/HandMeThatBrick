using HugsLib;
using Verse;

namespace HandMeThatBrick
{
	public class HMTB_Menu : ModBase
	{
    private const int HAUL_FRAME_HIGH_PRIORITY = 47;
    private const int HAUL_BLUEPRINT_HIGH_PRIORITY = 45;
    private const int HAUL_FRAME_LOW_PRIORITY = 7;
    private const int HAUL_BLUEPRINT_LOW_PRIORITY = 5;

    public override string ModIdentifier
		{
			get
			{
				return "HandMeThatBrick";
			}
		}

		public override void DefsLoaded()
		{
			HMTBDefs();
		}

		public override void SettingsChanged()
		{
			HMTBDefs();
		}

		private void HMTBDefs()
		{
			var haulersConstructionToggle = Settings.GetHandle<bool>("HaulersHelpConstruct", "HMTB_setting_haulersConstructionToggle_label".Translate(), "HMTB_setting_haulersConstructionToggle_desc".Translate(), true);
			HMTB_DefOf.HaulDeliverResourcesToFrames.scanThings = haulersConstructionToggle.Value;
			HMTB_DefOf.HaulDeliverResourcesToBlueprints.scanThings = haulersConstructionToggle.Value;

      var priorityToggle = Settings.GetHandle<bool>("HaulersConstructPriority", "HMTB_setting_haulerPriorityToggle_label".Translate(),
        "HMTB_setting_haulerPriorityToggle_desc".Translate(), defaultValue: true);
      HMTB_DefOf.HaulDeliverResourcesToFrames.priorityInType = (priorityToggle.Value ? HAUL_FRAME_HIGH_PRIORITY : HAUL_FRAME_LOW_PRIORITY) ;
      HMTB_DefOf.HaulDeliverResourcesToBlueprints.priorityInType = (priorityToggle.Value ? HAUL_BLUEPRINT_HIGH_PRIORITY : HAUL_BLUEPRINT_LOW_PRIORITY);
      Logger.Message("Priorities:" + HMTB_DefOf.HaulDeliverResourcesToBlueprints.priorityInType);
    }
	}
}