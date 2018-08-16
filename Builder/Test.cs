//test victim Builder
public class Test{

  void Start(){

    VictimBlueprint ethan = new Ethan();

    VictimDirector director = new VictimDirector(ethan);
    director.makeVictim();

  }

}
