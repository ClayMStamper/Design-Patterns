
public class PizzaMaker(){

  void Start(){

    Pizza myPizza = new TomatoSauce(new Mozzarella(new PizzaCrust()));

    Debug.Log ("My pizza: " + myPizza.GetDescription() + ", for: $" +
     myPizza.GetCost());

  }

}
