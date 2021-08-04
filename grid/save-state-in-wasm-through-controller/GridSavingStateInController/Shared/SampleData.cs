namespace GridSavingStateInController.Shared
{
    public class SampleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is SampleData)
            {
                return this.Id == (obj as SampleData).Id;
            }
            return false;
        }
    }
}
