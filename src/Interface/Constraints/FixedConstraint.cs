public class FixedConstraint : Constraint
{

    public int size = 0;

    public FixedConstraint(int _size)
    {

        size = _size;

    }

    public override int GetPosition(int start)
    {

        return start;

    }

    public override int GetSize()
    {

        return size;

    }

}