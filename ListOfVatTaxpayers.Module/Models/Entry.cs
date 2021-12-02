namespace ListOfVatTaxpayers.Module.Models
{
    class Entry
    {
        public string Identifier { get; set; }
        public Entity[] Subjects { get; set; }
    }
}
