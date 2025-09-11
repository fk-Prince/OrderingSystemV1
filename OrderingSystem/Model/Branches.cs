namespace OrderingSystem.Model
{
    public class Branches
    {
        private static int branch_id = 1;
        private string branch_code;
        private string branch_name;



        public static int Branch_ID { get => branch_id; set => branch_id = value; }
        public string Branch_code { get => branch_code; set => branch_code = value; }
        public string Branch_name { get => branch_name; set => branch_name = value; }
    }
}
