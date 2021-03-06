﻿using RimWorld;
using Verse;

namespace HandMeThatBrick
{
	public class WorkGiver_HaulDeliverResourcesToBlueprints : WorkGiver_ConstructDeliverResourcesToBlueprints
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t)
		{
			Blueprint blueprint = t as Blueprint;
			if (blueprint is Blueprint_Install)
			{
				return base.HasJobOnThing(pawn, t);
			}
			return base.HasJobOnThing(pawn, t) && !blueprint.MaterialsNeeded().NullOrEmpty();
		}
	}
}