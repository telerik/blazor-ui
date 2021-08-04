namespace GridSavingStateInController.Shared
{
    public class SampleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }

        // example of comparing stored items (from editing or selection)
        // with items from the current data source - IDs are used instead of the default references
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
