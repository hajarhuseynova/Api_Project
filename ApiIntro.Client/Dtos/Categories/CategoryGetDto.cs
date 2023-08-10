namespace ApiIntro.Client.Dtos.Categories
{
        public class CategoryGetDto
        {
            public string? name { get; set; }
         
        }

        public class GetItems<T>
        {
            public List<T> Items { get; set; }
        }
    
}
