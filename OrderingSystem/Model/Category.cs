namespace OrderingSystem.Model
{
    public class Category
    {
        private int category_id;
        private string category_name;

        public Category(int category_id, string category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }

        public int Category_id { get => category_id; }
        public string Category_name { get => category_name; }
    }
}
