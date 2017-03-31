namespace ProjectERP.Interfaces
{
    public interface IContentView
    {
        bool CanAddItem { get; set; }
        bool CanDeleteItem { get; set; }
        bool CanSaveItem { get; set; }

        //TODO osobny interfejs
        void AddToDatabase();
        void DeleteToDatabase();
    }
}