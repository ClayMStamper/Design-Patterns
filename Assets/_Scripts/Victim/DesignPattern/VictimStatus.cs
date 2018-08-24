//fully encapsulates victim status;
//no other class should handle and victim status data
public class VictimStatus : IVictimDefine
{

    public BodyPart head { get; }
    public BodyPart torso { get; }
    public BodyPart lArm { get; }
    public BodyPart rArm { get; }
    public BodyPart lLeg { get; }
    public BodyPart rLeg { get; }
    public BodyPart spine { get; }
    public BodyPart rHand { get; }
    public BodyPart lHand { get; }
    public BodyPart rFoot { get; }
    public BodyPart lFoot { get; }

    public void SetHead(BodyPart head)
    {
        this.head = head;
    }

    public void SetTorso(BodyPart torso)
    {
        this.torso = torso;
    }

    public void SetArms(BodyPart lArm, BodyPart rArm)
    {
        this.lArm = lArm;
        this.rArm = rArm;
    }

    public void SetLegs(BodyPart lLeg, BodyPart rLeg)
    {
        this.lLeg = lLeg;
        this.rLeg = rLeg;
    }

    public void SetSpine(BodyPart spine)
    {
        this.spine = spine;
    }

    public void SetHands(BodyPart rHand, BodyPart lHand)
    {
        this.rHand = rHand;
        this.lHand = lHand;
    }

    public void SetFeet(BodyPart rFoot, BodyPart lFoot)
    {
        this.rFoot = rFoot;
        this.lFoot = lFoot;
    }
}