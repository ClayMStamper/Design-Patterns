public class StockGrabber : Subject{

  private List <Observer> observers;
  private double ibmPrice;
  private double googPrice;
  private double aaplPrice;

//default constructor
  public StockGrabber (){
    observers = new List <Observer>();
  }

  public void Register(Observer newObs){
    observers.add (newObs);
  }

  public void Unregister (Observer oldObs){
    observers.remove (oldObs);
  }

  public void notifyObeserver(){

    foreach (Observer obs in observers){
      obs.DoUpdate(ibmPrice, aaplPrice, googPrice);
    }

  }

  public void SetIBMPrice (double newPrice){

    this.ibmPrice = newPrice;
    notifyObeserver();

  }

  public void SetAAPLPrice (double newPrice){

    this.aaplPrice = newPrice;
    notifyObeserver();

  }

  public void SetGOOGPrice (double newPrice){

    this.googPrice = newPrice;
    notifyObeserver();

  }

}
