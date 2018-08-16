public class Ethan : VictimBlueprint{

  private Victim victim;

  public Ethan(){
    this.victim = new Victim()
  }

  public void BuildHead(){

    victim.SetHead ("bleeding");

  }

  public void BuildTorso(){

    victim.SetTorso ("fine");

  }

  public void BuildArms(){

    victim.SetArms ("broken");

  }

  public void BuildLegs(){
    victim.SetLegs ("fine");
  }

  public Victim GetVictim (){
    create this.victim;
  }

}
