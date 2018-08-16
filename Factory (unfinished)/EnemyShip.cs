
public abstract class EnemyShip {

  private string name {get; set;}
  private double damage {get; set;}

  public void FollowPlayer(){
    //is following hero now
  }

  public void Display(){
    //display
  }

  public void Shoot(){
    Debug.Log (name + " attacks for " + damage);
  }

}
