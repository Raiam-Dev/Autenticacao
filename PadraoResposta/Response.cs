namespace Aplicacao.PadraoResposta
{
    public class ApiResponseModel<T>
    {
        public bool Success {get; set;}
        public string? Message {get; set;}
        public T data {get; set;}
    }
       

    public static class ApiResponse
    {
        public static ApiResponseModel<T> Success<T>(T data) {
            return new ApiResponseModel<T>()
            {
                Success = true,
                Message = null,
                data = data
            };
        }
        public static ApiResponseModel<T> Fail<T>(T data, string mensage)
        {
            return new ApiResponseModel<T>()
            {
                Success = false,
                Message = mensage,
                data = data
            };
        }

    }

}