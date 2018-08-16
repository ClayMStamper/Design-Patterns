public class StockObserver : Observer {

  private double ibmPrice;
  private double googPrice;
  private double aaplPrice;

  private static int observerIDTracker = 0;

  private int obeserverID;

  private Subject stockGrabber;

  public StockObserver (Subject stockGrabber) {

    this.stockGrabber = stockGrabber;
    this.observerID = ++observerID;

    Debug.Log ("New Observer: " + this.observerID);

    stockGrabber.Register (this);

  }

  public void DoUpdate(double ibmPrice, double aaplPrice, double googPrice){

    this.ibmPrice = ibmPrice;
    this.aaplPrice = aaplPrice;
    this.googPrice = googPrice;

  }

}
