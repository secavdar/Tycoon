namespace Project.Domain.Base
{
    using Model;
    public class Unit
    {
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public int EntityID { get; set; }
        public int LanguageID { get; set; }
        public string Text { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual Language Language { get; set; }
    }
}