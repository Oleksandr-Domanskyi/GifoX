using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GifoX.web.Models;

namespace GifoX.web.Service.IService
{
  public interface IBaseService
  {
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
  }
}