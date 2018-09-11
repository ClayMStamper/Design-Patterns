
public class Mozzarella : ToppingDecorator{

  public Mozzarella (Pizza newPizza){
    super (newPizza);

    Debug.Log ("Adding cheese...");

  }

  string GetDescription(){
    return tempPizza.GetDescription() + ", Mozzarella";
  }

  double GetCost(){
    return tempPizza.GetDescription() + 0.50;
  }

}
