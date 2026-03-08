namespace EmployeeAPI.Dtos
{
    public class JsonResponse
    {
        public static JsonResultModel Success(object data)
        {
            return new JsonResultModel(Constants.Constants.SUCCESS_CODE, Constants.Constants.SUCCESS_CODE, Constants.Constants.MESSAGE_SUCCESS, data);
        }

        public static JsonResultModel SuccessPaging(object data, object paging)
        {
            return new JsonResultModel(Constants.Constants.SUCCESS, Constants.Constants.SUCCESS_CODE, Constants.Constants.MESSAGE_SUCCESS, data, paging);
        }

        public static JsonResultModel Success(string message, object data)
        {
            return new JsonResultModel(Constants.Constants.SUCCESS, Constants.Constants.SUCCESS_CODE, message, data);
        }
        public static JsonResultModel Success(int code, object data)
        {
            return new JsonResultModel(Constants.Constants.SUCCESS, code, Constants.Constants.MESSAGE_SUCCESS, data);
        }
        public static JsonResultModel Success()
        {
            return new JsonResultModel(Constants.Constants.SUCCESS, Constants.Constants.SUCCESS_CODE, Constants.Constants.MESSAGE_SUCCESS, "");
        }
        // Trạng thái không thành công:
        public static JsonResultModel Error(int code, string message, object errors = null)
        {
            return new JsonResultModel(Constants.Constants.ERROR, code, message, "", errors: errors);
        }

        public static JsonResultModel Response(int status, int code, string message, object data)
        {
            return new JsonResultModel(status, code, message, data);
        }

        public static JsonResultModel ServerError()
        {
            return new JsonResultModel(Constants.Constants.ERROR, Constants.Constants.ERROR_CODE, Constants.Constants.SERVER_ERROR, "");
        }
    }
}
