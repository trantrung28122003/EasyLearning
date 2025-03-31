namespace EasyLearning.Infrastructure.Data.Abstraction
{
    public class ActionBaseResult<T> where T : GenericEntity
    {
        public bool IsSuccess { get; set; } 
        public string ActionName { get; set; } = string.Empty;
        public List<String> ErrorMessages { get; set; } = new List<string>();
        public T? DataObject { get; set; }
    }
}
