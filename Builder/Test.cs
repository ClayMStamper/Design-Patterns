//test victim Builder
public class Test{

  void Start(){

    VictimBlueprint ethan = new Ethan();

    //make the builder and give him ethan as the blueprint to build
    VictimBuilder builder = new VictimBuilder(ethan);
    builder.BuildVictim();

        //test
        Debug.Log(ethan.GetStatus().head);
        Debug.Log(ethan.GetStatus().torso);
        Debug.Log(ethan.GetStatus().arms);
        Debug.Log(ethan.GetStatus().legs);

        /*
         * fields won't be strings in the actualy implementation
         * and fields will likely be their own data structure. To keep this
         * test applicable, replace with a ToString() function attached to the body part class
         */ 
    }

}
