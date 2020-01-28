namespace Jumpings.Repos
{
    public class JumperRepo : BaseRepo<Jumper>, IJumperRepo
    {
        public JumperRepo(JumpingsContext context)
        {
            Context = context;
            Table = Context.Jumper;
        }
    }
}
