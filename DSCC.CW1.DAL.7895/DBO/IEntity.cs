namespace DSCC.CW1.DAL._7895.DBO
{
    public interface IEntity
    {
        //Id is used in Generic Repository 
        //which allows to define CRUD implementations under the same Id property
        public int Id { get; set; }
    }
}
