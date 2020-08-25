using System;

namespace ChristmasWeb
{
    public class Relative
    {
        public int      Id   { get; set;}
        public string   Name { get; set; }
        public int      Link { get; set; }

        public Relative(int id, string name)
        {
            this.Id   = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return "Relative: " + Name + ", Id: " + Id + ", LinkingId: " + Link;
        }


    }
}
