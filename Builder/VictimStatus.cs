//fully encapsulates victim status;
//no other class should handle and victim status data
public class VictimStatus : IVictimDefine{

public string head{get;}
public string torso{get;}
public string arms{get;}
public string legs{get;}

  public void SetHead (string head){
    this.head = head;
  }

  public void SetTorso (string torso){
    this.torso = torso;
  }

  public void SetArms (string arms){
    this.arms = arms;
  }

  public void SetLegs (string legs){
    this.legs = legs;
  }


}
