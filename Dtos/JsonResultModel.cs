namespace EmployeeAPI.Dtos
{
    public class JsonResultModel
    {
        public int status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object paging { get; set; } = null;
        public object errors { get; set; }

        public JsonResultModel(int status, int code, string message, object data, object? paging = null, object errors = null)
        {
            this.status = status;
            this.code = code;
            this.message = message;
            this.data = data;
            this.paging = paging;
            this.errors = errors;
        }
    }
}
