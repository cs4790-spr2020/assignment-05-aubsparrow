namespace BlabberApp.Domain
{
    public interface IDataStore
    {
      //CRUD
      bool Create(IDatum datum);
      IDatum Read(int index);
      bool Update(IDatum datum);
      bool Delete(int index);
    }
}