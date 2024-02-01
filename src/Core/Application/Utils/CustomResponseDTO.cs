using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Application.Utils
{
    public class CustomResponseDTO<T>
    {
        public T? Value { get; }
        public bool IsSuccess { get; }
        public CustomResponseDTO(T? value, bool isSuccess)
        {
            Value = value;
            IsSuccess = isSuccess;
        }
        public static CustomResponseDTO<T> Success(T? value)
        {
            return new CustomResponseDTO<T>(value, true);
        }
        public static CustomResponseDTO<T> Failure()
        {
            T defaultValue = default(T); // Bu değeri belirleyerek geçebilirsiniz.
            return new CustomResponseDTO<T>(value: defaultValue, isSuccess: false);
        }


        // public static CustomResponseDTO<T> Success(int statusCode, T data)
        // {
        //     return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode };
        // }
        // public static CustomResponseDTO<T> Success(int statusCode)
        // {
        //     return new CustomResponseDTO<T> { StatusCode = statusCode };
        // }
        // public static CustomResponseDTO<T> Fail(int statusCode, List<string> errors)
        // {
        //     return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = errors };
        // }
        // public static CustomResponseDTO<T> Fail(int statusCode, string error)
        // {
        //     return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<String> { error } };
        // }

        // public class ErrorViewModel
        // {
        //     public List<string> Errors { get; set; } = new List<string>();
        // }
        // public class NoContentDTO
        // {
        // }
    }
}