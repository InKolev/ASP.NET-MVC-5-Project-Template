namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class Workplace : BaseModel<int>
    {
        public string Name { get; set; }

        public string MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }

        public string MyProperty3 { get; set; }

        public string MyProperty4 { get; set; }

        public string MyProperty5 { get; set; }
    }
}
