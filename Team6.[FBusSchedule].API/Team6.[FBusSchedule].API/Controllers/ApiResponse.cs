namespace Team6._FBusSchedule_.API.Controllers
{
    internal class ApiResponse
    {
        public ApiResponse()
        {
        }

        public bool Success { get; set; }
        public string Messsage { get; set; }
        public object Data { get; set; }
    }
}