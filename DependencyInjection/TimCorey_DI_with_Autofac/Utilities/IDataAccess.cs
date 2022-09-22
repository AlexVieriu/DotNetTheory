namespace TimCorey_DI_with_Autofac.Utilities;

public interface IDataAccess
{
    void LoadData();
    void SaveData(string name);
}
