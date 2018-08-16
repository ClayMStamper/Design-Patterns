//victim engineer
public class VictimDirector{

  private VictimBlueprint victimBlueprint;

  public VictimDirector (VictimBlueprint VictimBlueprint){

    this.victimBlueprint = victimBlueprint;

  }

  public Victim GetVictim(){
    return this.victimBlueprint.GetVictim();
  }

  public void makeVictim(){

    victimBlueprint.BuildHead();
    victimBlueprint.BuildTorso();
    victimBlueprint.BuildLegs();
    victimBlueprint.BuildArms();

  }

}
