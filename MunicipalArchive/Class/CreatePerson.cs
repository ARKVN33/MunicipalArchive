namespace MunicipalArchive.Class
{
    public class CreatePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Father { get; set; }
        public string Code { get; set; }

        public CreatePerson(int id, string name, string family, string father, string code)
        {
            Id = id;
            Name = name;
            Family = family;
            Father = father;
            Code = code;
        }
    }
}
