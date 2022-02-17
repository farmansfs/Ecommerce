namespace Ecommerce.Responses
{
    public class SuccessResponse<T> : BaseResponse
    {
        public T Result { get; set; }
    }
}
