
public class Mozzarella : ToppingDecorator{

  public Mozzarella (Pizza newPizza){
    super (newPizza);

    Debug.Log ("Adding Sauce...");

  }

  string GetDescription(){
    return tempPizza.GetDescription() + ", Tomato Sauce";
  }

  double GetCost(){
    return tempPizza.GetDescription() + 0.25;
  }

}
