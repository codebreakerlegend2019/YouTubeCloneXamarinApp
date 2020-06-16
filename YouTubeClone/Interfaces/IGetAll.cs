using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeClone.Interfaces
{
    public interface IGetAll<T> where T : class
    {
        List<T> GetAll();
    }
}
