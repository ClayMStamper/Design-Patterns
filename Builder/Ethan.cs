//this is a blueprint for ethan and will be passed in as a blueprint
//to the VictimBuilder constructor (called in Test.cs)
public class Ethan : IVictimBlueprint{

  private VictimStatus status;

  public Ethan(){
        this.victim = new Victim();
  }

    #region these functions are what make Ethan unique. Change these to have custom victim qualities
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
    #endregion

    //returns victim status data structure
    public VictimStatus GetStatus (){
        return status;
  }

}
