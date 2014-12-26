using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.AutoMapper.Model
{
    public interface IOrderRepository
    {
        Order FindBy(int Id);
    }
}
