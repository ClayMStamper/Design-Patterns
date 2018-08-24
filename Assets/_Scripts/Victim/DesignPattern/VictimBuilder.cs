//victim engineer / director
public class VictimBuilder
{

    private VictimBlueprint victimBlueprint;

    public VictimBuilder(VictimBlueprint VictimBlueprint)
    {

        this.victimBlueprint = victimBlueprint;

    }

    public void BuildVictim()
    {

        victimBlueprint.BuildHead();
        victimBlueprint.BuildTorso();
        victimBlueprint.BuildLegs();
        victimBlueprint.BuildArms();

    }

}