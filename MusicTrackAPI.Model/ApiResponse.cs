namespace MusicTrackAPI.Model
{
    public class ApiResponse
    {
        public static ApiResponse Ok() => new ApiResponse(StatusCodes.OK, null);
        public static ApiResponse InternalServerError(string errorMessage) => new ApiResponse(StatusCodes.InternalServerError, errorMessage);


        public ApiResponse(uint status, string error)
        {
            Status = status;
            Error = error;
        }
        public uint Status { get; set; }
        public string Error { get; set; }
    }

    public class ApiResponse<TResult> : ApiResponse
    {
        public ApiResponse(TResult result)
            : base(StatusCodes.OK, null)
        {
            Result = result;
        }
        public TResult Result { get; set; }
    }
}
