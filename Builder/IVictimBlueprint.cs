//specific victims will implement this interface but will probably be generated procedurally
public interface IVictimBlueprint{

  public void BuildHead();
  public void BuildTorso();
  public void BuildArms();
  public void BuildLegs();

  public VictimStatus GetStatus();

}
