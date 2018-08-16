
public interface Flys {
  string Fly();
}

class CanFly : Flys {

  string Fly(){
    return ("can fly");
  }

}

class CantFly : Flys {

  string Fly(){
    return (" I can't fly");
  }

}
