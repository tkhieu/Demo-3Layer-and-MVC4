namespace Data_Transfer_Objects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassDTO Class { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }
    }
}