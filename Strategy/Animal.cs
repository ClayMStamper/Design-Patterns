public class Animal {

  public Flys flyingType;

  public string TryToFly(){
    return flyingType.Fly();
  }

  public void SetCanFly(Flys flyType){
    flyingType = flyType;
  }

  public Flys GetCanFly (){
    return flyingType;
  }

}
