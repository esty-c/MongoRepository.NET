using Newtonsoft.Json;

namespace MongoRepository.Infrastructure.Model
{
    public class Pagging
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("page_size")]
        public int PageSize { get; set; }
        [JsonProperty("total_page")]
        public int TotalPage { get; set; }

        public Pagging(int currentPage, int pageSize, int totalPage) {

            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalPage = totalPage;
        }
        public Pagging() { }
    }
}