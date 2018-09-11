
public class ToppingDecorator : Pizza {

  protected Pizza tempPizza;

  public ToppingDecorator (Pizza newPizza){
    tempp  = newPizza;
  }

  string GetDescription(){
    return tempPizza.GetDescription();;
  }

  double GetCost(){
    return tempPizza.GetCost();
  }

}
