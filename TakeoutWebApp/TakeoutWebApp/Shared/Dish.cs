namespace TakeoutWebApp.Shared
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int restaurant_id { get; set; }
    }
}
